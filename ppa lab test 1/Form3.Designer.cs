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
            Undo = new ToolStripButton();
            Redo = new ToolStripButton();
            Save = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            x1ToolStripMenuItem = new ToolStripMenuItem();
            x3ToolStripMenuItem = new ToolStripMenuItem();
            everyoneXEveryoneToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.White;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { Action, Undo, Redo, Save, toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // Action
            // 
            Action.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Action.DropDownItems.AddRange(new ToolStripItem[] { attackToolStripMenuItem, healToolStripMenuItem, cloneToolStripMenuItem });
            Action.Image = (Image)resources.GetObject("Action.Image");
            Action.ImageTransparentColor = Color.Magenta;
            Action.Name = "Action";
            Action.Size = new Size(34, 24);
            Action.Text = "Action";
            // 
            // attackToolStripMenuItem
            // 
            attackToolStripMenuItem.Name = "attackToolStripMenuItem";
            attackToolStripMenuItem.Size = new Size(134, 26);
            attackToolStripMenuItem.Text = "Attack";
            attackToolStripMenuItem.Click += attackToolStripMenuItem_Click;
            // 
            // healToolStripMenuItem
            // 
            healToolStripMenuItem.Name = "healToolStripMenuItem";
            healToolStripMenuItem.Size = new Size(134, 26);
            healToolStripMenuItem.Text = "Heal";
            // 
            // cloneToolStripMenuItem
            // 
            cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            cloneToolStripMenuItem.Size = new Size(134, 26);
            cloneToolStripMenuItem.Text = "Clone";
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
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.Info;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
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
            panel1.Controls.Add(splitContainer1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 397);
            panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Bottom;
            splitContainer1.Location = new Point(0, 346);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.Info;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.Info;
            splitContainer1.Size = new Size(800, 51);
            splitContainer1.SplitterDistance = 399;
            splitContainer1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(501, 128);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(134, 127);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(199, 128);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 127);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
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
            x3ToolStripMenuItem.Text = "3 vs 3";
            x3ToolStripMenuItem.Click += x3ToolStripMenuItem_Click;
            // 
            // everyoneXEveryoneToolStripMenuItem
            // 
            everyoneXEveryoneToolStripMenuItem.Name = "everyoneXEveryoneToolStripMenuItem";
            everyoneXEveryoneToolStripMenuItem.Size = new Size(233, 26);
            everyoneXEveryoneToolStripMenuItem.Text = "everyone vs everyone";
            everyoneXEveryoneToolStripMenuItem.Click += everyoneXEveryoneToolStripMenuItem_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "Form3";
            Text = "Form3";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private SplitContainer splitContainer1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem x1ToolStripMenuItem;
        private ToolStripMenuItem x3ToolStripMenuItem;
        private ToolStripMenuItem everyoneXEveryoneToolStripMenuItem;
    }
}