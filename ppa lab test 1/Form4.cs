﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ppa_lab_test_1
{
    public partial class Form4 : Form
    {
        string message;
        public Form4(string _message)
        {
            InitializeComponent();
            message = _message;
            label1.Text = message;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
