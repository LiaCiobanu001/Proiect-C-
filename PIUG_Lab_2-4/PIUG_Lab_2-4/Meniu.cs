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
    public partial class Meniu : Form
    {
        public Meniu()
        {

            InitializeComponent();
        }

        private void btnPaginaPrincipala_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new PaginaPrincipala();
            f.ShowDialog();
        }

       

        private void btnAdaugare_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form f = new AdaugarePastila();
            f.ShowDialog();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Doriti sa parasiti aplicatia ? ", "Fereastra de iesire", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                Application.Restart();
            }
        }

        private void btnVizualizarePastila_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new VizualizarePastila();
            f.ShowDialog();
        }

        private void Meniu_Load(object sender, EventArgs e)
        {
            string connect = @"Data Source=DESKTOP-NGROH08\WINCC;Initial Catalog=DateBunici;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            cnn.Open();
            string tabel_date = "select * from informatii personale";
            SqlDataAdapter da = new SqlDataAdapter(tabel_date, connect);
            DataSet ds = new DataSet();
            cnn.Close();
            da.Dispose();
            ds.Dispose();
        }
    }
}
