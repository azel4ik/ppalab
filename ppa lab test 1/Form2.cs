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

    public partial class Form2 : Form
    {
        //System.Media.SoundPlayer player1 = new System.Media.SoundPlayer();
        int wallet = 100;
        int balance;
        public Form2()
        {
            InitializeComponent();
            //player1.SoundLocation = "ThePyre.wav";
            //player1.Play();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (balance >= 0)
            {
                Game g = new Game();

                g.player.HICount = (int)HICount.Value;
                g.player.LICount = (int)LICount.Value;
                g.player.ACount = (int)ACount.Value;
                g.player.HCount = (int)HCount.Value;
                g.player.WCount = (int)WCount.Value;

                GameManager gm = new GameManager();
                GatherArmy ga = new GatherArmy(g);

                gm.SetCommand(ga);
                gm.Execute();
                Form3 f3 = new Form3(g);
                this.Hide();
                f3.Show();
            }
            else MessageBox.Show("Not enough money.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void HICount_ValueChanged(object sender, EventArgs e)
        {
            balance = wallet - (int)HICount.Value * (new HeavyUnit().Price) - (int)LICount.Value * (new LightUnit().Price) - (int)ACount.Value * (new Archer().Price) - (int)HCount.Value * (new Healer().Price);
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
