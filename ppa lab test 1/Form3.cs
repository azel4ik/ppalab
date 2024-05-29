using System;
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
        PictureBox[] pBoxAE = new PictureBox[4];
        Point[] pointsLine = new Point[4]
        {
            new Point(510, 400),
            new Point(405, 400),
            new Point(155, 400),
            new Point(30, 400),
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
            pBoxAE[0] = pictureBoxe1;
            pBoxAE[1] = pictureBoxe2;
            pBoxAE[2] = pictureBoxe3;
            pBoxAE[3] = pictureBoxe4;
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
            //
            fight = 1;
            for (int i = 0; i < game.player.units.Count(); i++)
            {
                pBoxAE[i].Location = pointsLine[i];
            }
            game.SetArmyPosition(new OnevsOnePosition());
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            fight = 2;
            pBoxAP[0].Location = new Point(331, 53);
            pBoxAP[1].Location = new Point(331, 160);
            pBoxAP[2].Location = new Point(131, 53);
            pBoxAP[3].Location = new Point(131, 160);
            game.SetArmyPosition(new ThreevsThreePosition());
        }

        private void everyoneXEveryoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            fight = 3;
            pBoxAP[0].Location = new Point(331, 53);
            pBoxAP[1].Location = new Point(331, 110);
            pBoxAP[2].Location = new Point(331, 160);
            pBoxAP[3].Location = new Point(331, 2100);
            game.SetArmyPosition(new AllvsAllPosition());
        }
    }
}
