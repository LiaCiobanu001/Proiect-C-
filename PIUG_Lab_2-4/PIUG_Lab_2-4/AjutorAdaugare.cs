﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIUG_Lab_2_4
{
    public partial class AjutorAdaugare : Form
    {
        public AjutorAdaugare()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new AdaugarePastila();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Meniu();
            f.ShowDialog();
        }
    }
}
