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

    public partial class Form3 : Form
    {
        System.Media.SoundPlayer player3 = new System.Media.SoundPlayer();
        System.Media.SoundPlayer effectplayer = new System.Media.SoundPlayer();
        Game g;
        GameManager gm = new GameManager();

        public Form3(Game game)
        {
            InitializeComponent();
            g = game;
            player3.SoundLocation = "Battle.wav";
            //effectplayer.SoundLocation = "sword-clash.wav";
            player3.PlayLooping();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveGame sg = new SaveGame(g);
            gm.SetCommand(sg);
            gm.Execute();
        }

        private void attackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeMove mm = new MakeMove(g);
            gm.SetCommand(mm);
            gm.Execute();
            pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //effectplayer.Play();
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
