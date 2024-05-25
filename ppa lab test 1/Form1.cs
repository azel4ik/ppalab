namespace ppa_lab_test_1
{

    public partial class Form1 : Form
    {
        Game g;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public Form1()
        {
            InitializeComponent();
            player.SoundLocation = "ThePyre.wav";
            player.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            this.Hide();
            //player.Stop();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}