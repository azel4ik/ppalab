namespace The_Greatest_Dance_Off
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
            label1 = new Label();
            label2 = new Label();
            NewGameBt = new Button();
            LoadGameBt = new Button();
            LeaderbordBt = new Button();
            ExitBt = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Harlow Solid Italic", 48F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkViolet;
            label1.Location = new Point(373, 55);
            label1.Name = "label1";
            label1.Size = new Size(440, 101);
            label1.TabIndex = 0;
            label1.Text = "The greatest";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AccessibleDescription = "heyy";
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Popup;
            label2.Font = new Font("79", 72F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.DeepPink;
            label2.Location = new Point(190, 174);
            label2.Name = "label2";
            label2.Size = new Size(883, 105);
            label2.TabIndex = 1;
            label2.Text = "Dance-off";
            label2.Click += label2_Click;
            // 
            // NewGameBt
            // 
            NewGameBt.Anchor = AnchorStyles.Top;
            NewGameBt.Cursor = Cursors.Hand;
            NewGameBt.FlatAppearance.BorderSize = 0;
            NewGameBt.FlatStyle = FlatStyle.Flat;
            NewGameBt.Font = new Font("Retro Star", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            NewGameBt.ForeColor = Color.DarkViolet;
            NewGameBt.Location = new Point(390, 282);
            NewGameBt.Name = "NewGameBt";
            NewGameBt.Size = new Size(423, 75);
            NewGameBt.TabIndex = 2;
            NewGameBt.Text = "New game";
            NewGameBt.UseVisualStyleBackColor = true;
            NewGameBt.Click += NewGameBt_Click;
            // 
            // LoadGameBt
            // 
            LoadGameBt.Anchor = AnchorStyles.Top;
            LoadGameBt.Cursor = Cursors.Hand;
            LoadGameBt.FlatAppearance.BorderSize = 0;
            LoadGameBt.FlatStyle = FlatStyle.Flat;
            LoadGameBt.Font = new Font("Retro Star", 24F, FontStyle.Regular, GraphicsUnit.Point);
            LoadGameBt.ForeColor = Color.DarkViolet;
            LoadGameBt.Location = new Point(390, 373);
            LoadGameBt.Name = "LoadGameBt";
            LoadGameBt.Size = new Size(423, 75);
            LoadGameBt.TabIndex = 3;
            LoadGameBt.Text = "Load game";
            LoadGameBt.UseVisualStyleBackColor = true;
            // 
            // LeaderbordBt
            // 
            LeaderbordBt.Anchor = AnchorStyles.Top;
            LeaderbordBt.Cursor = Cursors.Hand;
            LeaderbordBt.FlatAppearance.BorderSize = 0;
            LeaderbordBt.FlatStyle = FlatStyle.Flat;
            LeaderbordBt.Font = new Font("Retro Star", 24F, FontStyle.Regular, GraphicsUnit.Point);
            LeaderbordBt.ForeColor = Color.DarkViolet;
            LeaderbordBt.Location = new Point(390, 466);
            LeaderbordBt.Name = "LeaderbordBt";
            LeaderbordBt.Size = new Size(423, 75);
            LeaderbordBt.TabIndex = 4;
            LeaderbordBt.Text = "Leaderboard";
            LeaderbordBt.UseVisualStyleBackColor = true;
            // 
            // ExitBt
            // 
            ExitBt.Anchor = AnchorStyles.Top;
            ExitBt.Cursor = Cursors.Hand;
            ExitBt.FlatAppearance.BorderSize = 0;
            ExitBt.FlatStyle = FlatStyle.Flat;
            ExitBt.Font = new Font("Retro Star", 24F, FontStyle.Regular, GraphicsUnit.Point);
            ExitBt.ForeColor = Color.DarkViolet;
            ExitBt.Location = new Point(390, 561);
            ExitBt.Name = "ExitBt";
            ExitBt.Size = new Size(423, 75);
            ExitBt.TabIndex = 5;
            ExitBt.Text = "Exit";
            ExitBt.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Gold;
            ClientSize = new Size(1180, 680);
            Controls.Add(ExitBt);
            Controls.Add(LeaderbordBt);
            Controls.Add(LoadGameBt);
            Controls.Add(NewGameBt);
            Controls.Add(label2);
            Controls.Add(label1);
            MinimumSize = new Size(1198, 727);
            Name = "Form1";
            Text = "The Greatest Dance-off";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button NewGameBt;
        private Button LoadGameBt;
        private Button LeaderbordBt;
        private Button ExitBt;
    }
}