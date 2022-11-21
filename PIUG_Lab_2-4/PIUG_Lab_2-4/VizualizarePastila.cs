using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIUG_Lab_2_4
{
    public partial class VizualizarePastila : Form
    {
        public VizualizarePastila()
        {
            InitializeComponent();
        }

        private void VizualizarePastila_Load(object sender, EventArgs e)
        {

            string connect = @"Data Source=DESKTOP-NGROH08\WINCC;Initial Catalog=DateBunici;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            cnn.Open();
            string tabel_date = "select * from Pastile";
            SqlDataAdapter da = new SqlDataAdapter(tabel_date, connect);
            DataSet ds = new DataSet();
            da.Fill(ds, "Pastile");
            dataGridView1.DataSource = ds.Tables["Pastile"].DefaultView;
            cnn.Close();
            da.Dispose();
            ds.Dispose();

        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            string connect = @"Data Source=DESKTOP-NGROH08\WINCC;Initial Catalog=DateBunici;Integrated Security=True";
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            string stmt = "select * from Pastile where Denumire='" + txtCautaPastila.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(stmt, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Pastile");
            dataGridView1.DataSource = ds.Tables["Pastile"].DefaultView;
            con.Close();
            da.Dispose();
            ds.Dispose();
        }



        private void btnStergere_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                string connect = @"Data Source=DESKTOP-NGROH08\WINCC;Initial Catalog=DateBunici;Integrated Security=True";
                SqlConnection con = new SqlConnection(connect);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from Pastile where Denumire='" + txtCautaPastila.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                con.Close();
                MessageBox.Show("Stergere finalizata cu succes!");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            DialogResult result = MessageBox.Show("Datale vor fi sterse!", "Stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string connect = @"Data Source=DESKTOP-NGROH08\WINCC;Initial Catalog=DateBunici;Integrated Security=True";
                SqlConnection con = new SqlConnection(connect);
                con.Open();

                foreach (DataGridViewCell onecell in dataGridView1.SelectedCells)
                {
                    if (onecell.Selected)
                    {
                        dataGridView1.Rows.RemoveAt(onecell.RowIndex);
                        try
                        {
                            /// con.Open();
                            SqlCommand cmd = new SqlCommand("delete from Pastile where Denumire='" + txtCautaPastila.Text + "'", con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            dataGridView1.Update();
                            dataGridView1.Refresh();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        MessageBox.Show("Stergerea a fost efectuata cu succes!");
                    }
                }
            }
            else 
            {
                this.Hide();
                Form f = new Meniu();
                f.ShowDialog();
            }
        }

            private void button1_Click(object sender, EventArgs e)
            {
                this.Hide();
                Form f = new Meniu();
                f.ShowDialog();
            }
        
    }
}
