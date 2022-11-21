using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIUG_Lab_2_4
{
    public partial class Autentificare : Form
    {
        public Autentificare()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] utilizatori = File.ReadAllLines("utilizatori.txt");
            foreach (var line in utilizatori)
            {
                string[] inregistrare = line.Split(',');
                comboBoxUtilizatori.Items.Add(inregistrare[0]);
            }
          
        }

        private int incercari = 0;
        private void btnAutentificare_Click(object sender, EventArgs e)
        {
            string[] utilizatori = File.ReadAllLines("utilizatori.txt");
           
            foreach (var line in utilizatori)
            {
                string[] inregistrare = line.Split(',');
                if((comboBoxUtilizatori.Text).Equals(inregistrare[0]))
                {
                    if((txtParola.Text.Trim()).Equals(inregistrare[1].Trim()))
                    {
                        if (checkBox1.Checked == true)
                        {
                            this.Hide();
                            Form m = new Meniu();
                            m.ShowDialog();
                          
                        }
                        else
                        {
                            MessageBox.Show("Bifati casuta!");
                        }
                    }
                    else
                    {
                        incercari++;
                        MessageBox.Show("Parola incorecta! Mai aveti " + (3 -incercari).ToString() + " incercari.");
                    }
                }
                if (incercari ==3)
                    Application.Exit();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inregistrare i= new Inregistrare();
            i.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
