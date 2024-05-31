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

    public partial class Form2 : Form
    {
        System.Media.SoundPlayer player1 = new System.Media.SoundPlayer();
        int wallet = 100;
        int balance = 100;
        public Form2()
        {
            InitializeComponent();
            label3.Text = $"Heavy Infantry ({new HeavyUnit().Price})";
            label4.Text = $"Light Infantry ({new LightUnit().Price})";
            label5.Text = $"Archers ({new Archer().Price})";
            label6.Text = $"Healers ({new Healer().Price})";
            label7.Text = $"Wizards ({new Wizard().Price})";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (balance >= 0 && balance != wallet)
            {
                Game g = new Game();

                g.player.HICount = (int)HICount.Value;
                g.player.LICount = (int)LICount.Value;
                g.player.ACount = (int)ACount.Value;
                g.player.HCount = (int)HCount.Value;
                g.player.WCount = (int)WCount.Value;

                GameManager gm = new GameManager();
                GatherArmy ga = new GatherArmy(g, wallet - balance);

                player1.Stop();
                gm.SetCommand(ga);
                gm.Execute();
                Form3 f3 = new Form3(g);
                this.Hide();
                f3.Show();
            }
            else if (balance < 0)
            {
                Form4 f4 = new Form4("Not enough money...");
                f4.Show();
            }
            else
            {
                Form4 f4 = new Form4("Choose some units first...");
                f4.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            Hide();
            f1.Show();
        }

        private void HICount_ValueChanged(object sender, EventArgs e)
        {
            int HIPrice = (int)HICount.Value * new HeavyUnit().Price;
            int LIPrice = (int)LICount.Value * new LightUnit().Price;
            int APrice = (int)ACount.Value * new Archer().Price;
            int HPrice = (int)HCount.Value * new Healer().Price;
            int WPrice = (int)WCount.Value * new Wizard().Price;
            int Total = HIPrice + LIPrice + APrice + HPrice + WPrice;
            balance = wallet - Total;
            label2.Text = $"{balance}";
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {

            if (balance < 0)
            {
                label2.Text = "0";
                label2.ForeColor = Color.Red;
            }
            else label2.ForeColor = Color.Ivory;

        }

        //private void HICount_Click(object sender, EventArgs e)
        //{
        //    if ()label7.Text += "0";
        //}

    }
}
