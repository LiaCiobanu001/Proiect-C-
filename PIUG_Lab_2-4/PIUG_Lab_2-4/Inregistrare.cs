﻿using System;
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
    public partial class Inregistrare : Form
    {
        public Inregistrare()
        {
            InitializeComponent();
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            timer1.Start();
            using (StreamWriter w = File.AppendText("utilizatori.txt"))
            {
                w.WriteLine(textBox1.Text+","+textBox2.Text);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 10;
            progressBar1.Value -= 1;
            progressBar1.Value += 1;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                MessageBox.Show("Inregistrare reusita!");
                Application.Restart();
            }
        }
    }
}
