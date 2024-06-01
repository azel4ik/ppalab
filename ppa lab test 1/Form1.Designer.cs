namespace ppa_lab_test_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            NewGame = new Button();
            ExitButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Pfeffer Mediæval", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(241, 5);
            label1.Name = "label1";
            label1.Size = new Size(326, 83);
            label1.TabIndex = 0;
            label1.Text = "Game name";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // NewGame
            // 
            NewGame.Anchor = AnchorStyles.Top;
            NewGame.BackColor = Color.Transparent;
            NewGame.Cursor = Cursors.Hand;
            NewGame.FlatStyle = FlatStyle.Flat;
            NewGame.Font = new Font("Pfeffer Mediæval", 23.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            NewGame.ForeColor = Color.Gold;
            NewGame.Location = new Point(272, 308);
            NewGame.Name = "NewGame";
            NewGame.Size = new Size(250, 52);
            NewGame.TabIndex = 1;
            NewGame.Text = "New Game";
            NewGame.UseVisualStyleBackColor = false;
            NewGame.Click += button1_Click;
            // 
            // ExitButton
            // 
            ExitButton.Anchor = AnchorStyles.Top;
            ExitButton.BackColor = Color.Transparent;
            ExitButton.Cursor = Cursors.Hand;
            ExitButton.FlatStyle = FlatStyle.Flat;
            ExitButton.Font = new Font("Pfeffer Mediæval", 23.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            ExitButton.ForeColor = Color.Gold;
            ExitButton.Location = new Point(272, 386);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(250, 52);
            ExitButton.TabIndex = 3;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = false;
            ExitButton.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(ExitButton);
            Controls.Add(NewGame);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button NewGame;
        private Button ExitButton;
    }
}