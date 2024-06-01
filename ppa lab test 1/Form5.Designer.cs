namespace ppa_lab_test_1
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            backtomenubt = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // backtomenubt
            // 
            backtomenubt.Anchor = AnchorStyles.Bottom;
            backtomenubt.BackColor = Color.Transparent;
            backtomenubt.FlatStyle = FlatStyle.Flat;
            backtomenubt.Font = new Font("Pfeffer Mediæval", 23.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            backtomenubt.ForeColor = Color.Gold;
            backtomenubt.Location = new Point(242, 324);
            backtomenubt.Name = "backtomenubt";
            backtomenubt.Size = new Size(331, 86);
            backtomenubt.TabIndex = 0;
            backtomenubt.Text = "Back to Menu";
            backtomenubt.UseVisualStyleBackColor = false;
            backtomenubt.Click += backtomenubt_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Gold;
            label1.Font = new Font("Pfeffer Mediæval", 23.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(351, 165);
            label1.Name = "label1";
            label1.Size = new Size(105, 55);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(backtomenubt);
            Name = "Form5";
            Text = "Form5";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backtomenubt;
        private Label label1;
    }
}