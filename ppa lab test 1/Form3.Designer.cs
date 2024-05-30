namespace ppa_lab_test_1
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            toolStrip1 = new ToolStrip();
            Action = new ToolStripDropDownButton();
            attackToolStripMenuItem = new ToolStripMenuItem();
            healToolStripMenuItem = new ToolStripMenuItem();
            cloneToolStripMenuItem = new ToolStripMenuItem();
            gulyaiToolStripMenuItem = new ToolStripMenuItem();
            Undo = new ToolStripButton();
            Redo = new ToolStripButton();
            Save = new ToolStripButton();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            x1ToolStripMenuItem = new ToolStripMenuItem();
            x3ToolStripMenuItem = new ToolStripMenuItem();
            everyoneXEveryoneToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            panel1 = new Panel();
            ggE = new PictureBox();
            pictureBoxe5 = new PictureBox();
            pictureBoxe4 = new PictureBox();
            pictureBoxe3 = new PictureBox();
            pictureBoxe2 = new PictureBox();
            pictureBoxe1 = new PictureBox();
            pictureBoxp5 = new PictureBox();
            ggP = new PictureBox();
            pictureBoxp3 = new PictureBox();
            pictureBoxp2 = new PictureBox();
            pictureBoxp1 = new PictureBox();
            pictureBoxp4 = new PictureBox();
            splitContainer1 = new SplitContainer();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ggE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxe5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxe4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxe3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxe2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxe1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxp5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ggP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxp3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxp2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxp1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxp4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.White;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { Action, Undo, Redo, Save, toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1700, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // Action
            // 
            Action.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Action.DropDownItems.AddRange(new ToolStripItem[] { attackToolStripMenuItem, healToolStripMenuItem, cloneToolStripMenuItem, gulyaiToolStripMenuItem });
            Action.Image = (Image)resources.GetObject("Action.Image");
            Action.ImageTransparentColor = Color.Magenta;
            Action.Name = "Action";
            Action.Size = new Size(34, 24);
            Action.Text = "Action";
            // 
            // attackToolStripMenuItem
            // 
            attackToolStripMenuItem.Name = "attackToolStripMenuItem";
            attackToolStripMenuItem.Size = new Size(224, 26);
            attackToolStripMenuItem.Text = "Attack";
            attackToolStripMenuItem.Click += attackToolStripMenuItem_Click;
            // 
            // healToolStripMenuItem
            // 
            healToolStripMenuItem.Name = "healToolStripMenuItem";
            healToolStripMenuItem.Size = new Size(224, 26);
            healToolStripMenuItem.Text = "Heal";
            // 
            // cloneToolStripMenuItem
            // 
            cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            cloneToolStripMenuItem.Size = new Size(224, 26);
            cloneToolStripMenuItem.Text = "Clone";
            // 
            // gulyaiToolStripMenuItem
            // 
            gulyaiToolStripMenuItem.Name = "gulyaiToolStripMenuItem";
            gulyaiToolStripMenuItem.Size = new Size(224, 26);
            gulyaiToolStripMenuItem.Text = "Gulyai-Gorod";
            gulyaiToolStripMenuItem.Click += gulyaiToolStripMenuItem_Click;
            // 
            // Undo
            // 
            Undo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Undo.Image = (Image)resources.GetObject("Undo.Image");
            Undo.ImageTransparentColor = Color.Magenta;
            Undo.Name = "Undo";
            Undo.Size = new Size(29, 24);
            Undo.Text = "Undo";
            Undo.Click += Undo_Click;
            // 
            // Redo
            // 
            Redo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Redo.Image = (Image)resources.GetObject("Redo.Image");
            Redo.ImageTransparentColor = Color.Magenta;
            Redo.Name = "Redo";
            Redo.Size = new Size(29, 24);
            Redo.Text = "Redo";
            Redo.Click += Redo_Click;
            // 
            // Save
            // 
            Save.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Save.Image = (Image)resources.GetObject("Save.Image");
            Save.ImageTransparentColor = Color.Magenta;
            Save.Name = "Save";
            Save.Size = new Size(29, 24);
            Save.Text = "Save";
            Save.Click += Save_Click;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { x1ToolStripMenuItem, x3ToolStripMenuItem, everyoneXEveryoneToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(34, 24);
            toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // x1ToolStripMenuItem
            // 
            x1ToolStripMenuItem.Name = "x1ToolStripMenuItem";
            x1ToolStripMenuItem.Size = new Size(233, 26);
            x1ToolStripMenuItem.Text = "1 vs 1";
            x1ToolStripMenuItem.Click += x1ToolStripMenuItem_Click;
            // 
            // x3ToolStripMenuItem
            // 
            x3ToolStripMenuItem.Name = "x3ToolStripMenuItem";
            x3ToolStripMenuItem.Size = new Size(233, 26);
            x3ToolStripMenuItem.Text = "2 vs 2";
            x3ToolStripMenuItem.Click += x3ToolStripMenuItem_Click;
            // 
            // everyoneXEveryoneToolStripMenuItem
            // 
            everyoneXEveryoneToolStripMenuItem.Name = "everyoneXEveryoneToolStripMenuItem";
            everyoneXEveryoneToolStripMenuItem.Size = new Size(233, 26);
            everyoneXEveryoneToolStripMenuItem.Text = "everyone vs everyone";
            everyoneXEveryoneToolStripMenuItem.Click += everyoneXEveryoneToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.Info;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 924);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1700, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(151, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(151, 20);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(ggE);
            panel1.Controls.Add(pictureBoxe5);
            panel1.Controls.Add(pictureBoxe4);
            panel1.Controls.Add(pictureBoxe3);
            panel1.Controls.Add(pictureBoxe2);
            panel1.Controls.Add(pictureBoxe1);
            panel1.Controls.Add(pictureBoxp5);
            panel1.Controls.Add(ggP);
            panel1.Controls.Add(pictureBoxp3);
            panel1.Controls.Add(pictureBoxp2);
            panel1.Controls.Add(pictureBoxp1);
            panel1.Controls.Add(pictureBoxp4);
            panel1.Controls.Add(splitContainer1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(1700, 897);
            panel1.TabIndex = 2;
            // 
            // ggE
            // 
            ggE.AccessibleName = "";
            ggE.BackColor = Color.Transparent;
            ggE.Location = new Point(915, 400);
            ggE.Name = "ggE";
            ggE.Size = new Size(130, 140);
            ggE.TabIndex = 16;
            ggE.TabStop = false;
            ggE.Tag = "";
            // 
            // pictureBoxe5
            // 
            pictureBoxe5.AccessibleName = "";
            pictureBoxe5.BackColor = Color.Transparent;
            pictureBoxe5.Location = new Point(1550, 400);
            pictureBoxe5.Name = "pictureBoxe5";
            pictureBoxe5.Size = new Size(120, 140);
            pictureBoxe5.TabIndex = 15;
            pictureBoxe5.TabStop = false;
            pictureBoxe5.Tag = "";
            // 
            // pictureBoxe4
            // 
            pictureBoxe4.AccessibleName = "";
            pictureBoxe4.BackColor = Color.Transparent;
            pictureBoxe4.Location = new Point(1425, 400);
            pictureBoxe4.Name = "pictureBoxe4";
            pictureBoxe4.Size = new Size(120, 140);
            pictureBoxe4.TabIndex = 14;
            pictureBoxe4.TabStop = false;
            pictureBoxe4.Tag = "";
            // 
            // pictureBoxe3
            // 
            pictureBoxe3.AccessibleName = "";
            pictureBoxe3.BackColor = Color.Transparent;
            pictureBoxe3.Location = new Point(1300, 400);
            pictureBoxe3.Name = "pictureBoxe3";
            pictureBoxe3.Size = new Size(120, 140);
            pictureBoxe3.TabIndex = 13;
            pictureBoxe3.TabStop = false;
            pictureBoxe3.Tag = "";
            // 
            // pictureBoxe2
            // 
            pictureBoxe2.AccessibleName = "";
            pictureBoxe2.BackColor = Color.Transparent;
            pictureBoxe2.Location = new Point(1175, 400);
            pictureBoxe2.Name = "pictureBoxe2";
            pictureBoxe2.Size = new Size(120, 140);
            pictureBoxe2.TabIndex = 12;
            pictureBoxe2.TabStop = false;
            pictureBoxe2.Tag = "";
            // 
            // pictureBoxe1
            // 
            pictureBoxe1.AccessibleName = "";
            pictureBoxe1.BackColor = Color.Transparent;
            pictureBoxe1.Location = new Point(1050, 400);
            pictureBoxe1.Name = "pictureBoxe1";
            pictureBoxe1.Size = new Size(120, 140);
            pictureBoxe1.TabIndex = 11;
            pictureBoxe1.TabStop = false;
            pictureBoxe1.Tag = "";
            // 
            // pictureBoxp5
            // 
            pictureBoxp5.BackColor = Color.Transparent;
            pictureBoxp5.Location = new Point(30, 400);
            pictureBoxp5.Name = "pictureBoxp5";
            pictureBoxp5.Size = new Size(120, 140);
            pictureBoxp5.TabIndex = 10;
            pictureBoxp5.TabStop = false;
            // 
            // ggP
            // 
            ggP.AccessibleName = "";
            ggP.BackColor = Color.Transparent;
            ggP.Location = new Point(655, 400);
            ggP.Name = "ggP";
            ggP.Size = new Size(130, 140);
            ggP.TabIndex = 9;
            ggP.TabStop = false;
            ggP.Tag = "";
            // 
            // pictureBoxp3
            // 
            pictureBoxp3.BackColor = Color.Transparent;
            pictureBoxp3.Location = new Point(280, 400);
            pictureBoxp3.Name = "pictureBoxp3";
            pictureBoxp3.Size = new Size(120, 140);
            pictureBoxp3.TabIndex = 8;
            pictureBoxp3.TabStop = false;
            // 
            // pictureBoxp2
            // 
            pictureBoxp2.BackColor = Color.Transparent;
            pictureBoxp2.Location = new Point(405, 400);
            pictureBoxp2.Name = "pictureBoxp2";
            pictureBoxp2.Size = new Size(120, 140);
            pictureBoxp2.TabIndex = 7;
            pictureBoxp2.TabStop = false;
            // 
            // pictureBoxp1
            // 
            pictureBoxp1.AccessibleName = "";
            pictureBoxp1.BackColor = Color.Transparent;
            pictureBoxp1.Location = new Point(530, 400);
            pictureBoxp1.Name = "pictureBoxp1";
            pictureBoxp1.Size = new Size(120, 140);
            pictureBoxp1.TabIndex = 6;
            pictureBoxp1.TabStop = false;
            pictureBoxp1.Tag = "";
            // 
            // pictureBoxp4
            // 
            pictureBoxp4.BackColor = Color.Transparent;
            pictureBoxp4.Location = new Point(155, 400);
            pictureBoxp4.Name = "pictureBoxp4";
            pictureBoxp4.Size = new Size(120, 140);
            pictureBoxp4.TabIndex = 5;
            pictureBoxp4.TabStop = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Bottom;
            splitContainer1.Location = new Point(0, 846);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.Info;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.Info;
            splitContainer1.Size = new Size(1700, 51);
            splitContainer1.SplitterDistance = 842;
            splitContainer1.TabIndex = 2;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1700, 950);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            DoubleBuffered = true;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form3";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ggE).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxe5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxe4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxe3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxe2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxe1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxp5).EndInit();
            ((System.ComponentModel.ISupportInitialize)ggP).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxp3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxp2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxp1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxp4).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripDropDownButton Action;
        private ToolStripMenuItem attackToolStripMenuItem;
        private ToolStripMenuItem healToolStripMenuItem;
        private ToolStripMenuItem cloneToolStripMenuItem;
        private ToolStripButton Undo;
        private ToolStripButton Redo;
        private ToolStripButton Save;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem x1ToolStripMenuItem;
        private ToolStripMenuItem x3ToolStripMenuItem;
        private ToolStripMenuItem everyoneXEveryoneToolStripMenuItem;
        public PictureBox pictureBoxp3;
        public PictureBox pictureBoxp2;
        public PictureBox pictureBoxp1;
        public PictureBox pictureBoxp4;
        public PictureBox ggP;
        public PictureBox pictureBoxp5;
        public PictureBox pictureBoxe5;
        public PictureBox pictureBoxe4;
        public PictureBox pictureBoxe3;
        public PictureBox pictureBoxe2;
        public PictureBox pictureBoxe1;
        public PictureBox ggE;
        private ToolStripMenuItem gulyaigorodToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem gulyaiToolStripMenuItem;
    }
}