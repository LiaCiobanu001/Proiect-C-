using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PIUG_Lab_2_4
{
    public partial class PaginaPrincipala : Form
    {
        string cnp;
        public PaginaPrincipala()
        {
            InitializeComponent();
            // cnp = cnp_selectat;
        }
        SqlConnection cnn = new SqlConnection(ConexiuneBD.string_connect);

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new AdaugarePastila();
            f.ShowDialog();
        }

        private void btnVizualizare_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new VizualizarePastila();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Meniu();
            f.ShowDialog();
        }

        public static bool verificCNP(string cnp)
        {
            //https://ro.wikipedia.org/wiki/Cod_numeric_personal
            int s, a1, a2, l1, l2, z1, z2, j1, j2, n1, n2, n3, cifc, u;
            if (cnp.Trim().Length != 13)
                return false;
            else
            {
                s = Convert.ToInt16(cnp.Substring(0, 1));
                a1 = Convert.ToInt16(cnp.Substring(1, 1));
                a2 = Convert.ToInt16(cnp.Substring(2, 1));
                l1 = Convert.ToInt16(cnp.Substring(3, 1));
                l2 = Convert.ToInt16(cnp.Substring(4, 1));
                z1 = Convert.ToInt16(cnp.Substring(5, 1));
                z2 = Convert.ToInt16(cnp.Substring(6, 1));
                j1 = Convert.ToInt16(cnp.Substring(7, 1));
                j2 = Convert.ToInt16(cnp.Substring(8, 1));
                n1 = Convert.ToInt16(cnp.Substring(9, 1));
                n2 = Convert.ToInt16(cnp.Substring(10, 1));
                n3 = Convert.ToInt16(cnp.Substring(11, 1));
                cifc = Convert.ToInt16(((s * 2 + a1 * 7 + a2 * 9 + l1 * 1 + l2 * 4 + z1
               * 6 + z2 * 3 + j1 * 5 + j2 * 8 + n1 * 2 + n2 * 7 + n3 * 9) % 11));
                if (cifc == 10)
                {
                    cifc = 1;
                }
                u = Convert.ToInt16(cnp.Substring(12, 1));
                if (cifc == u)
                    return true;
                else
                    return false;
            }
        }

        private void btnValidareCNP_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtCNP.Text))
            {
                MessageBox.Show("Introduceti CNP!", "CNP");
            }
            else
            {
                string connect = @"Data Source=DESKTOP-NGROH08\WINCC;Initial Catalog=DateBunici;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connect);
                try
                {
                    string query = "select * from InfoPacient where CNP='" + txtCNP.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cnn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtNume.Text = dr["Nume"].ToString();
                        txtPrenume.Text = dr["Prenume"].ToString();
                        txtGen.Text = dr["Gen"].ToString();
                        txtMedic.Text = dr["Medic"].ToString();
                        txtTutore.Text = dr["Tutore"].ToString();
                        txtCNP.Text = dr["CNP"].ToString();
                        dateTimePicker1.Text = dr["Data nasterii"].ToString();

                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare: " + ex.Message);
                }
            }

        }
    }
}
