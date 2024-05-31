using System;
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
    public partial class Form5 : Form
    {
        public Form5(bool b)
        {
            InitializeComponent();
            if (b) label1.Text = "You Won!";
            else label1.Text = "You Lost...";
        }

        private void backtomenubt_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            Hide();
            f1.Show();
        }
    }
}
