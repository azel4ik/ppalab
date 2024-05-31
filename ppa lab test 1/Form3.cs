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
        //points
        #region
        PictureBox[] pBoxAP = new PictureBox[5];
        PictureBox[] pBoxAE = new PictureBox[5];
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
            new Point(1050, 250),
            new Point(1050, 430),
            new Point(1175, 250),
            new Point(1175, 430),
            new Point(1300, 250),
        };
        Point[] pointsWallP = new Point[5]
        {
            new Point(530, 35),
            new Point(530, 190),
            new Point(530, 345),
            new Point(530, 500),
            new Point(530, 655),
        };
        Point[] pointsWallE = new Point[5]
        {
            new Point(1050, 35),
            new Point(1050, 190),
            new Point(1050, 345),
            new Point(1050, 500),
            new Point(1050, 655),
        };
        #endregion
        private WaveStream bcgstream;
        private WaveOut outbcg;

        public Game game;
        GameManager gm = new GameManager();

        public int fight = 0;
        private int currentIndex = 0;

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
            pBoxAP[4] = pictureBoxp5;
            pBoxAE[0] = pictureBoxe1;
            pBoxAE[1] = pictureBoxe2;
            pBoxAE[2] = pictureBoxe3;
            pBoxAE[3] = pictureBoxe4;
            pBoxAE[4] = pictureBoxe5;
            for (int i = 0; i < g.player.units.Count(); i++)
            {
                pBoxAP[i].Image = g.player.units[i].ImgsP.StandingStill;
            }
            for (int i = 0; i < g.enemy.units.Count(); i++)
            {
                pBoxAE[i].Image = g.enemy.units[i].ImgsE.StandingStill;
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
            if (game.Over)
            {
                Hide();
                Form5 f5 = new Form5(game.EndGame());
                f5.Show();
            }
            if (fight == 1)
            {
                #region
                pBoxAP[0].Image = game.player.units[0].ImgsP.BasicAttack;
                pBoxAE[0].Image = game.enemy.units[0].ImgsE.BasicAttack;
                Timer archer = new Timer();
                archer.Interval = 3000; // 5 seconds
                Timer healer = new Timer();
                healer.Interval = 3000; // 5 seconds
                Timer stand = new Timer();
                stand.Interval = 3000; // 5 seconds
                archer.Tick += (sender, args) =>
                {
                    //здесь кидает исключение из-за того, что одна из армий нулевая в конце игры
                    pBoxAP[0].Image = game.player.units[game.player.units.Count() - 1].ImgsP.StandingStill;
                    pBoxAE[0].Image = game.enemy.units[game.enemy.units.Count() - 1].ImgsE.StandingStill;
                    // After 5 seconds, restore the original image
                    for (int i = 0; i < game.player.units.Count() - 1; i++)
                    {
                        if (game.player.units[i].Name.Contains("Archer"))
                        {
                            pBoxAP[i + 1].Image = game.player.units[i].ImgsP.Special;
                        }
                    }
                    for (int i = 0; i < game.enemy.units.Count() - 1; i++)
                    {
                        if (game.enemy.units[i].Name.Contains("Archer"))
                        {
                            pBoxAE[i + 1].Image = game.enemy.units[i].ImgsE.Special;
                        }

                    }
                    stand.Start();
                    archer.Stop();
                    healer.Start();

                };
                archer.Start();
                healer.Tick += (sender, args) =>
                {
                    pBoxAP[0].Image = game.player.units[game.player.units.Count() - 1].ImgsP.StandingStill;
                    pBoxAE[0].Image = game.enemy.units[game.enemy.units.Count() - 1].ImgsE.StandingStill;
                    // After 5 seconds, restore the original image
                    for (int i = 0; i < game.player.units.Count() - 1; i++)
                    {
                        if (game.player.units[i].Name.Contains("Healer"))
                        {
                            pBoxAP[i + 1].Image = game.player.units[i].ImgsP.Special;
                        }

                    }
                    for (int i = 0; i < game.enemy.units.Count() - 1; i++)
                    {
                        if (game.enemy.units[i].Name.Contains("Healer"))
                        {
                            pBoxAE[i + 1].Image = game.enemy.units[i].ImgsE.Special;
                        }

                    }
                    healer.Stop();
                };
                stand.Tick += (sender, args) =>
                {
                    pBoxAP[0].Image = game.player.units[game.player.units.Count() - 1].ImgsP.StandingStill;
                    pBoxAE[0].Image = game.enemy.units[game.enemy.units.Count() - 1].ImgsE.StandingStill;
                    // After 5 seconds, restore the original image
                    for (int i = 0; i < game.player.units.Count() - 1; i++)
                    {
                        if (game.player.units[i].Name.Contains("Archer"))
                        {
                            pBoxAP[i + 1].Image = game.player.units[i].ImgsP.StandingStill;
                        }

                    }
                    for (int i = 0; i < game.enemy.units.Count() - 1; i++)
                    {
                        if (game.enemy.units[i].Name.Contains("Archer"))
                        {
                            pBoxAE[i + 1].Image = game.enemy.units[i].ImgsE.StandingStill;
                        }

                    }
                    stand.Stop();
                };
                #endregion
            }
            if (fight == 2)
            {
                pBoxAP[0].Image = game.player.units[0].ImgsP.BasicAttack;
                pBoxAP[1].Image = game.player.units[1].ImgsP.BasicAttack;
                pBoxAE[0].Image = game.enemy.units[0].ImgsE.BasicAttack;
                pBoxAE[1].Image = game.enemy.units[1].ImgsE.BasicAttack;
                Timer pauseTimer = new Timer();
                pauseTimer.Interval = 5000; // 5 seconds
                pauseTimer.Tick += (sender, args) =>
                {
                    // After 5 seconds, restore the original image
                    for (int i = 0; i < game.player.units.Count(); i++)
                    {
                        pBoxAP[i].Image = game.player.units[i].ImgsP.StandingStill;
                    }
                    //for (int i = 0; i < game.enemy.units.Count(); i++)
                    //{
                    //    pBoxAE[i].Image = game.enemy.units[i].ImgsE.StandingStill;
                    //}
                    for (int i = 0; i < game.player.units.Count(); i++)
                    {
                        if (game.player.units[i].Name == "Archer")
                        {
                            pBoxAP[i].Image = game.player.units[i].ImgsE.Special;
                        }
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
                for (int i = 0; i < game.enemy.units.Count(); i++)
                {
                    pBoxAE[i].Image = game.enemy.units[i].ImgsE.BasicAttack;
                }
            }
 

            MakeMove mm = new MakeMove(game);
            gm.SetCommand(mm);
            gm.Execute();



            Timer firstpos = new Timer();
            firstpos.Interval = 9000; // 5 seconds
            firstpos.Tick += (sender, args) =>
            {
                // After 5 seconds, restore the original image
                for (int i = 0; i < game.player.units.Count(); i++)
                {
                    pBoxAP[i].Image = game.player.units[i].ImgsP.StandingStill;

                }
                for (int i = 0; i < game.enemy.units.Count(); i++)
                {
                    pBoxAE[i].Image = game.enemy.units[i].ImgsE.StandingStill;

                }
                firstpos.Stop();
            };
            firstpos.Start();
            Timer death = new Timer();
            Timer clear = new Timer();
            death.Interval = 10000; // 5 seconds
            clear.Interval = 11000; // 5 seconds
            death.Tick += (sender, args) =>
            {
                // After 5 seconds, restore the original image
                for (int i = 0; i < game.player.units.Count(); i++)
                {
                    if (game.player.units[i].Health == 0)
                    {
                        pBoxAP[i].Image = game.player.units[i].ImgsP.Dead;
                    }

                }
                for (int i = 0; i < game.enemy.units.Count(); i++)
                {
                    if (game.enemy.units[i].Health == 0)
                    {
                        pBoxAE[i].Image = game.enemy.units[i].ImgsE.Dead;
                    }

                }
                death.Stop();
            };
            death.Start();
            clear.Tick += (sender, args) =>
            {
                // After 5 seconds, restore the original image
                for (int i = 0; i < game.player.units.Count(); i++)
                {
                    if (game.player.units[i].Health == 0)
                    {
                        pBoxAP[i].Image = null;
                        pBoxAP[i].BackColor = Color.Transparent;
                    }
                }
                for (int i = 0; i < game.enemy.units.Count(); i++)
                {
                    if (game.enemy.units[i].Health == 0)
                    {
                        pBoxAE[i].Image = null;
                        pBoxAE[i].BackColor = Color.Transparent;
                    }
                }
                clear.Stop();
            };
            clear.Start();

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



        private void x1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fight = 1;
            for (int i = 0; i < game.player.units.Count(); i++)
            {
                pBoxAP[i].Location = pointsLineP[i];
            }
            for (int i = 0; i < game.enemy.units.Count(); i++)
            {
                pBoxAE[i].Location = pointsLineE[i];
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
            }
            for (int i = 0; i < game.enemy.units.Count(); i++)
            {
                pBoxAE[i].Location = pointsTwoLineE[i];
            }
            game.SetArmyPosition(new ThreevsThreePosition());
        }

        private void everyoneXEveryoneToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fight = 3;
            for (int i = 0; i < game.player.units.Count(); i++)
            {
                pBoxAP[i].Location = pointsWallP[i];
            }
            for (int i = 0; i < game.enemy.units.Count(); i++)
            {
                pBoxAE[i].Location = pointsWallE[i];
            }
            game.SetArmyPosition(new AllvsAllPosition());
        }

        private void gulyaigorodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ggP.Image != null)
            {
                MessageBox.Show("You already have gulyai-gorod");
            }
            else
            {
                PlaceGulyaiGorod pgg = new PlaceGulyaiGorod(game);
                gm.SetCommand(pgg);
                gm.Execute();
                ggP.Image = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
                //ggE.Image = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            }

        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //если у нас еще нет клона:
            CloneUnit cu = new CloneUnit(game);
            gm.SetCommand(cu);
            gm.Execute();
            //pBoxAP[4].Image = game.player.units[4].ImgsP.StandingStill;
        }

        private void playUpToTheEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (ggP.Image != null)
            //{
            //    MessageBox.Show("You already have gulyai-gorod");
            //}
            //else
            //{
            //    PlaceGulyaiGorod pgg = new PlaceGulyaiGorod(game);
            //    gm.SetCommand(pgg);
            //    gm.Execute();
            //    ggP.Image = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //}
            PlayUpToTheEnd playUpToTheEnd = new PlayUpToTheEnd(game);
            gm.SetCommand(playUpToTheEnd);
            gm.Execute();
            Hide();
            Form5 f5 = new Form5(game.EndGame());
            f5.Show();
        }
    }
}

