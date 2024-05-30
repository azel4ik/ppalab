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
        PictureBox[] pBoxAP = new PictureBox[5];
        PictureBox[] pBoxAE = new PictureBox[4];
        Point[] pointsLineP = new Point[5]
        {
            new Point(530, 400),
            new Point(405, 400),
            new Point(280, 400),
            new Point(155, 400),
            new Point(30, 400),
        };
        Point[] pointsLineE = new Point[5]
        {
            new Point(1050, 400),
            new Point(1175, 400),
            new Point(1300, 400),
            new Point(1425, 400),
            new Point(1550, 400),
        };
        Point[] pointsTwoLineP = new Point[5]
        {
            new Point(530, 250),
            new Point(530, 430),
            new Point(405, 250),
            new Point(405, 430),
            new Point(280, 250),
        };
        Point[] pointsTwoLineE = new Point[5]
        {
            new Point(1050, 400),
            new Point(1175, 400),
            new Point(1300, 400),
            new Point(1425, 400),
            new Point(1550, 400),
        };
        Point[] pointsWallP = new Point[5]
        {
            new Point(530, 50),
            new Point(530, 240),
            new Point(530, 430),
            new Point(530, 620),
            new Point(530, 810),
        };
        Point[] pointsWallE = new Point[5]
        {
            new Point(1050, 400),
            new Point(1175, 400),
            new Point(1300, 400),
            new Point(1425, 400),
            new Point(1550, 400),
        };

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
            PictureBox gulgor = ggP;
            pBoxAP[0] = pictureBoxp1;
            pBoxAP[1] = pictureBoxp2;
            pBoxAP[2] = pictureBoxp3;
            pBoxAP[3] = pictureBoxp4;
            pBoxAP[5] = pictureBoxp5;
            //pBoxAE[0] = pictureBoxe1;
            //pBoxAE[1] = pictureBoxe2;
            //pBoxAE[2] = pictureBoxe3;
            //pBoxAE[3] = pictureBoxe4;
            //pBoxAE[4] = pictureBoxe5;
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


            if (fight == 1)
            {
                pBoxAP[0].Image = game.player.units[0].ImgsP.BasicAttack;
                Timer pauseTimer = new Timer();
                pauseTimer.Interval = 6000; // 5 seconds
                pauseTimer.Tick += (sender, args) =>
                {
                    // After 5 seconds, restore the original image
                    for (int i = 0; i < game.player.units.Count(); i++)
                    {
                        pBoxAP[i].Image = game.player.units[i].ImgsP.StandingStill;
                    }
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
                    for (int i = 0; i < game.player.units.Count(); i++)
                    {
                        pBoxAP[i].Image = game.player.units[i].ImgsP.StandingStill;
                    }
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
            }
            MakeMove mm = new MakeMove(game);
            gm.SetCommand(mm);
            gm.Execute();

        }

        private void Action_Click(object sender, EventArgs e)
        {

        }

        private void Undo_Click(object sender, EventArgs e)
        {
            gm.Undo();
            for (int i = 0; i < game.player.units.Count(); i++)
            {
                pBoxAP[i].Image = game.player.units[i].ImgsP.StandingStill;
            }

        }

        private void Redo_Click(object sender, EventArgs e)
        {
            gm.Redo();
            for (int i = 0; i < game.player.units.Count(); i++)
            {
                pBoxAP[i].Image = game.player.units[i].ImgsP.StandingStill;
            }

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void x1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fight = 1;
            for (int i = 0; i < game.player.units.Count(); i++)
            {
                pBoxAP[i].Location = pointsLineP[i];
                //pBoxAE[i].Location = pointsLineE[i];
            }
            game.SetArmyPosition(new OnevsOnePosition());
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            fight = 2;
            for (int i = 0; i < game.player.units.Count(); i++)
            {
                pBoxAP[i].Location = pointsTwoLineP[i];
                //pBoxAE[i].Location = pointsLineE[i];
            }
            game.SetArmyPosition(new ThreevsThreePosition());
        }

        private void everyoneXEveryoneToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fight = 3;
            for (int i = 0; i < game.player.units.Count(); i++)
            {
                pBoxAP[i].Location = pointsWallP[i];
                //pBoxAE[i].Location = pointsLineE[i];
            }
            game.SetArmyPosition(new AllvsAllPosition());
        }
    }
}
