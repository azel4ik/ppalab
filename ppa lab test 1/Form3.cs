﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using Timer = System.Windows.Forms.Timer;

namespace ppa_lab_test_1
{

    public partial class Form3 : Form
    {
        PictureBox[] pBoxAP = new PictureBox[4];

        private WaveStream bcgstream;
        private WaveOut outbcg;

        public Game game;
        GameManager gm = new GameManager();

        public int fight = 0;

        public Form3(Game g)
        {
            InitializeComponent();
            game = g;
            fight = 1;
            pBoxAP[0] = pictureBoxp1;
            pBoxAP[1] = pictureBoxp2;
            pBoxAP[2] = pictureBoxp3;
            pBoxAP[3] = pictureBoxp4;
            for (int i = 0; i < g.player.units.Count(); i++)
            {
                pBoxAP[i].Image = g.player.units[i].ImgsP.StandingStill;
            }
            bcgstream = new AudioFileReader("Battle.wav");
            LoopStream loop = new LoopStream(bcgstream);
            outbcg = new();
            outbcg.Init(loop);
            bcgstream.CurrentTime = new TimeSpan(0L);
            outbcg.Play();
            Invalidate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveGame sg = new SaveGame(game);
            gm.SetCommand(sg);
            gm.Execute();
        }

        private void attackToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MakeMove mm = new MakeMove(game);
            gm.SetCommand(mm);
            gm.Execute();
            if (fight == 1)
            {
                pBoxAP[0].Image = game.player.units[0].ImgsP.BasicAttack;
                Timer pauseTimer = new Timer();
                pauseTimer.Interval = 5000; // 5 seconds
                pauseTimer.Tick += (sender, args) =>
                {
                    // After 5 seconds, restore the original image
                    pBoxAP[0].Image = game.player.units[0].ImgsP.StandingStill;
                    pauseTimer.Stop();
                };
                pauseTimer.Start();
            }
            if (fight == 2)
            {
                pBoxAP[0].Image = game.player.units[0].ImgsP.BasicAttack;
                pBoxAP[1].Image = game.player.units[1].ImgsP.BasicAttack;
                Timer pauseTimer = new Timer();
                pauseTimer.Interval = 5000; // 5 seconds
                pauseTimer.Tick += (sender, args) =>
                {
                    // After 5 seconds, restore the original image
                    pBoxAP[0].Image = game.player.units[0].ImgsP.StandingStill;
                    pBoxAP[1].Image = game.player.units[1].ImgsP.StandingStill;
                    pauseTimer.Stop();
                };
                pauseTimer.Start();
            }
            if (fight == 3)
            {
                for (int i = 0; i < game.player.units.Count(); i++)
                {
                    pBoxAP[i].Image = game.player.units[i].ImgsP.BasicAttack;
                }
                Timer pauseTimer = new Timer();
                pauseTimer.Interval = 5000; // 5 seconds
                pauseTimer.Tick += (sender, args) =>
                {
                    for (int i = 0; i < game.player.units.Count(); i++)
                    {
                        pBoxAP[i].Image = game.player.units[i].ImgsP.StandingStill;
                    }
                    pauseTimer.Stop();
                };
                pauseTimer.Start();
            }

        }

        private void Action_Click(object sender, EventArgs e)
        {

        }

        private void Undo_Click(object sender, EventArgs e)
        {
            gm.Undo();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            gm.Redo();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void x1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.SetArmyPosition(new OnevsOnePosition());
            fight = 1;
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //game.SetArmyPosition(new ThreevsThreePosition());
            fight = 2;
            pBoxAP[0].Location = new Point(331, 53);
            pBoxAP[1].Location = new Point(331, 160);
            pBoxAP[2].Location = new Point(131, 53);
            pBoxAP[3].Location = new Point(131, 160);
        }

        private void everyoneXEveryoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.SetArmyPosition(new AllvsAllPosition());
            fight = 3;
            pBoxAP[0].Location = new Point(331, 53);
            pBoxAP[1].Location = new Point(331, 110);
            pBoxAP[2].Location = new Point(331, 160);
            pBoxAP[3].Location = new Point(331, 2100);
        }
    }
}
