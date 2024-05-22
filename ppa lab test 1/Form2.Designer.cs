namespace ppa_lab_test_1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            HICount = new NumericUpDown();
            WCount = new NumericUpDown();
            LICount = new NumericUpDown();
            ACount = new NumericUpDown();
            HCount = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)HICount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LICount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ACount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HCount).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Pfeffer Mediæval", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(165, 9);
            label1.Name = "label1";
            label1.Size = new Size(485, 83);
            label1.TabIndex = 0;
            label1.Text = "Choose your army";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Left;
            button1.BackColor = Color.Transparent;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Pfeffer Mediæval", 23.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.Gold;
            button1.Location = new Point(18, 384);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(167, 51);
            button1.TabIndex = 1;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Right;
            button2.BackColor = Color.Transparent;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Pfeffer Mediæval", 23.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.Gold;
            button2.Location = new Point(621, 384);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(167, 51);
            button2.TabIndex = 2;
            button2.Text = "Next";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Pfeffer Mediæval", 23.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(370, 380);
            label2.Name = "label2";
            label2.Size = new Size(74, 55);
            label2.TabIndex = 5;
            label2.Text = "100";
            label2.TextChanged += label2_TextChanged;
            // 
            // HICount
            // 
            HICount.Anchor = AnchorStyles.Top;
            HICount.BackColor = SystemColors.Info;
            HICount.Font = new Font("Pfeffer Mediæval", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            HICount.Location = new Point(272, 96);
            HICount.Margin = new Padding(3, 4, 3, 4);
            HICount.Name = "HICount";
            HICount.Size = new Size(150, 35);
            HICount.TabIndex = 6;
            HICount.ValueChanged += HICount_ValueChanged;
            // 
            // WCount
            // 
            WCount.Anchor = AnchorStyles.Top;
            WCount.BackColor = SystemColors.Info;
            WCount.Font = new Font("Pfeffer Mediæval", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            WCount.Location = new Point(621, 156);
            WCount.Margin = new Padding(3, 4, 3, 4);
            WCount.Name = "WCount";
            WCount.Size = new Size(150, 35);
            WCount.TabIndex = 7;
            WCount.ValueChanged += HICount_ValueChanged;
            // 
            // LICount
            // 
            LICount.Anchor = AnchorStyles.Top;
            LICount.BackColor = SystemColors.Info;
            LICount.Font = new Font("Pfeffer Mediæval", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            LICount.Location = new Point(272, 156);
            LICount.Margin = new Padding(3, 4, 3, 4);
            LICount.Name = "LICount";
            LICount.Size = new Size(150, 35);
            LICount.TabIndex = 8;
            LICount.ValueChanged += HICount_ValueChanged;
            // 
            // ACount
            // 
            ACount.Anchor = AnchorStyles.Top;
            ACount.BackColor = SystemColors.Info;
            ACount.Font = new Font("Pfeffer Mediæval", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            ACount.Location = new Point(272, 226);
            ACount.Margin = new Padding(3, 4, 3, 4);
            ACount.Name = "ACount";
            ACount.Size = new Size(150, 35);
            ACount.TabIndex = 9;
            ACount.ValueChanged += HICount_ValueChanged;
            // 
            // HCount
            // 
            HCount.Anchor = AnchorStyles.Top;
            HCount.BackColor = SystemColors.Info;
            HCount.Font = new Font("Pfeffer Mediæval", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            HCount.Location = new Point(621, 96);
            HCount.Margin = new Padding(3, 4, 3, 4);
            HCount.Name = "HCount";
            HCount.Size = new Size(150, 35);
            HCount.TabIndex = 10;
            HCount.ValueChanged += HICount_ValueChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Pfeffer Mediæval", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(91, 96);
            label3.Name = "label3";
            label3.Size = new Size(170, 28);
            label3.TabIndex = 11;
            label3.Text = "Heavy Infantry(20)";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Pfeffer Mediæval", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(91, 156);
            label4.Name = "label4";
            label4.Size = new Size(165, 28);
            label4.TabIndex = 12;
            label4.Text = "Light Infantry (10)";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Pfeffer Mediæval", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(91, 226);
            label5.Name = "label5";
            label5.Size = new Size(115, 28);
            label5.TabIndex = 13;
            label5.Text = "Archers (30)";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Pfeffer Mediæval", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(472, 98);
            label6.Name = "label6";
            label6.Size = new Size(112, 28);
            label6.TabIndex = 14;
            label6.Text = "Healers (35)";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Pfeffer Mediæval", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(472, 164);
            label7.Name = "label7";
            label7.Size = new Size(119, 28);
            label7.TabIndex = 15;
            label7.Text = "Wizards (35)";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 449);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(HCount);
            Controls.Add(ACount);
            Controls.Add(LICount);
            Controls.Add(WCount);
            Controls.Add(HICount);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)HICount).EndInit();
            ((System.ComponentModel.ISupportInitialize)WCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)LICount).EndInit();
            ((System.ComponentModel.ISupportInitialize)ACount).EndInit();
            ((System.ComponentModel.ISupportInitialize)HCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
        private NumericUpDown HICount;
        private NumericUpDown WCount;
        private NumericUpDown LICount;
        private NumericUpDown ACount;
        private NumericUpDown HCount;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
//{new HeavyUnit().Price}
//{new LightUnit().Price}
//{new Archer().Price}
//{new Healer().Price}