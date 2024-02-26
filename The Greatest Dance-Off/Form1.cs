namespace The_Greatest_Dance_Off
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NewGameBt_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            ActiveForm.Hide();
            f.Show();
        }
    }
}