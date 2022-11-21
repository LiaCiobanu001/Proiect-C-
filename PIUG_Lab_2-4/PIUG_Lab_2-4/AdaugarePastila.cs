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
    public partial class AdaugarePastila : Form
    {
        public AdaugarePastila()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new AjutorAdaugare();
            f.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Datele vor fi salvate!","Salvare",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(txtDenumire.Text) || String.IsNullOrEmpty(txtDiagnostice.Text) || String.IsNullOrEmpty(txtTimpadministrare.Text)
                    || String.IsNullOrEmpty(txtComentariu.Text))
                {
                    MessageBox.Show("Completati toate casutele!", "Error");
                }
                else
                {
                    try
                    {
                        string connect = @"Data Source=DESKTOP-NGROH08\WINCC;Initial Catalog=DateBunici;Integrated Security=True";
                        SqlConnection cnn = new SqlConnection(connect);
                        cnn.Open();
                        string stmt = "insert into Pastile ([Denumire], [Diagnostic], [Timp administrare], [Start administrare], [Comentariu])" +
                            " values(@d,@dia,@ta,@sa,@cm)";
                        SqlCommand sc = new SqlCommand(stmt, cnn);
                        sc.Parameters.AddWithValue("@d", txtDenumire.Text);
                        sc.Parameters.AddWithValue("@dia", txtDiagnostice.Text);
                        sc.Parameters.AddWithValue("@ta", txtTimpadministrare.Text);
                        sc.Parameters.AddWithValue("@sa", dateTimePicker1.Value);
                        sc.Parameters.AddWithValue("@cm", txtComentariu.Text);
                        sc.ExecuteNonQuery();
                        this.Hide();
                        Form f = new Meniu();
                        f.ShowDialog();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare", "Eroare!");
                    }
                } 

            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Salvarea s-a anulat!", "Anulare",MessageBoxButtons.OK);
            }
            else 
            {
                this.Hide();
                Form f =new Meniu();
                f.ShowDialog();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Meniu();
            f.ShowDialog();
        }
    }
}
