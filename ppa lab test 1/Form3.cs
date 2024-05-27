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

namespace ppa_lab_test_1
{

    public partial class Form3 : Form
    {
        //System.Media.SoundPlayer player3 = new System.Media.SoundPlayer();
        //System.Media.SoundPlayer effectplayer = new System.Media.SoundPlayer();
        private WaveStream bcgstream;
        private WaveOut outbcg;
        private WaveStream deatheffectstream;
        private WaveOut outdeatheffect;

        public Game game;
        GameManager gm = new GameManager();

        public Form3(Game g)
        {
            InitializeComponent();
            game = g;
            bcgstream = new AudioFileReader("Battle.wav");
            outbcg = new();
            outbcg.Init(bcgstream);
            //deatheffectstream = new AudioFileReader("sword-clash.wav");
            //outdeatheffect = new();
            //outdeatheffect.Init(deatheffectstream);
            bcgstream.CurrentTime = new TimeSpan(0L);
            outbcg.Play();
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
            pictureBox2.Image = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //deatheffectstream.CurrentTime = new TimeSpan(0L);
            //outdeatheffect.Play();
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
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.SetArmyPosition(new ThreevsThreePosition());

        }

        private void everyoneXEveryoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.SetArmyPosition(new AllvsAllPosition());

        }


    }
}
