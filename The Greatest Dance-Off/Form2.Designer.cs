namespace The_Greatest_Dance_Off
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
            tableLayoutPanel1 = new TableLayoutPanel();
            button7 = new Button();
            button6 = new Button();
            button1 = new Button();
            button4 = new Button();
            button8 = new Button();
            button3 = new Button();
            button2 = new Button();
            button5 = new Button();
            BacktoMenuBt = new Button();
            ConfirmBt = new Button();
            BudgetLabel = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("79", 72F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DeepPink;
            label1.Location = new Point(75, 53);
            label1.Name = "label1";
            label1.Size = new Size(1051, 105);
            label1.TabIndex = 0;
            label1.Text = "Make a team";
            label1.Click += label1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 265F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 264F));
            tableLayoutPanel1.Controls.Add(button7, 2, 1);
            tableLayoutPanel1.Controls.Add(button6, 1, 1);
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(button4, 3, 1);
            tableLayoutPanel1.Controls.Add(button8, 3, 0);
            tableLayoutPanel1.Controls.Add(button3, 2, 0);
            tableLayoutPanel1.Controls.Add(button2, 1, 0);
            tableLayoutPanel1.Controls.Add(button5, 0, 1);
            tableLayoutPanel1.Location = new Point(71, 174);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1055, 415);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // button7
            // 
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.Location = new Point(529, 210);
            button7.Name = "button7";
            button7.Size = new Size(259, 202);
            button7.TabIndex = 6;
            button7.Text = " ";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.ImageAlign = ContentAlignment.TopCenter;
            button6.Location = new Point(266, 210);
            button6.Name = "button6";
            button6.Size = new Size(257, 202);
            button6.TabIndex = 5;
            button6.Text = " ";
            button6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.AccessibleDescription = "heyy";
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(257, 201);
            button1.TabIndex = 0;
            button1.Text = " ";
            button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(794, 210);
            button4.Name = "button4";
            button4.Size = new Size(258, 202);
            button4.TabIndex = 3;
            button4.Text = " ";
            button4.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.Location = new Point(794, 3);
            button8.Name = "button8";
            button8.Size = new Size(258, 201);
            button8.TabIndex = 7;
            button8.Text = " ";
            button8.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.TopLeft;
            button3.Location = new Point(529, 3);
            button3.Name = "button3";
            button3.Size = new Size(259, 201);
            button3.TabIndex = 2;
            button3.Text = " ";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(266, 3);
            button2.Name = "button2";
            button2.Size = new Size(257, 201);
            button2.TabIndex = 1;
            button2.Text = " ";
            button2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.TopCenter;
            button5.Location = new Point(3, 210);
            button5.Name = "button5";
            button5.Size = new Size(257, 202);
            button5.TabIndex = 4;
            button5.Text = " ";
            button5.UseVisualStyleBackColor = true;
            // 
            // BacktoMenuBt
            // 
            BacktoMenuBt.Location = new Point(12, 614);
            BacktoMenuBt.Name = "BacktoMenuBt";
            BacktoMenuBt.Size = new Size(135, 49);
            BacktoMenuBt.TabIndex = 2;
            BacktoMenuBt.Text = "Back to menu";
            BacktoMenuBt.UseVisualStyleBackColor = true;
            BacktoMenuBt.Click += BacktoMenuBt_Click;
            // 
            // ConfirmBt
            // 
            ConfirmBt.Location = new Point(1028, 614);
            ConfirmBt.Name = "ConfirmBt";
            ConfirmBt.Size = new Size(140, 49);
            ConfirmBt.TabIndex = 3;
            ConfirmBt.Text = "Confirm!";
            ConfirmBt.UseVisualStyleBackColor = true;
            // 
            // BudgetLabel
            // 
            BudgetLabel.AutoSize = true;
            BudgetLabel.Location = new Point(562, 643);
            BudgetLabel.Name = "BudgetLabel";
            BudgetLabel.Size = new Size(33, 20);
            BudgetLabel.TabIndex = 4;
            BudgetLabel.Text = "100";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 680);
            Controls.Add(BudgetLabel);
            Controls.Add(ConfirmBt);
            Controls.Add(BacktoMenuBt);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            MinimumSize = new Size(1198, 727);
            Name = "Form2";
            Text = "The Greatest Dance-off";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button1;
        private Button button2;
        private Button BacktoMenuBt;
        private Button ConfirmBt;
        private Label BudgetLabel;
    }
}