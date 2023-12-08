namespace Picture_Viewer
{
    partial class Viewer
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
            PicBx = new PictureBox();
            menu = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            openSubMenuItem = new ToolStripMenuItem();
            exitSubMenuItem = new ToolStripMenuItem();
            settingsMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            lblActualImageFilePath = new Label();
            ((System.ComponentModel.ISupportInitialize)PicBx).BeginInit();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // PicBx
            // 
            PicBx.Dock = DockStyle.Fill;
            PicBx.Location = new Point(0, 24);
            PicBx.Name = "PicBx";
            PicBx.Size = new Size(800, 426);
            PicBx.TabIndex = 0;
            PicBx.TabStop = false;
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { fileMenuItem, settingsMenuItem, aboutMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(800, 24);
            menu.TabIndex = 1;
            menu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openSubMenuItem, exitSubMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(35, 20);
            fileMenuItem.Text = "file";
            // 
            // openSubMenuItem
            // 
            openSubMenuItem.Name = "openSubMenuItem";
            openSubMenuItem.Size = new Size(101, 22);
            openSubMenuItem.Text = "open";
            // 
            // exitSubMenuItem
            // 
            exitSubMenuItem.Name = "exitSubMenuItem";
            exitSubMenuItem.Size = new Size(101, 22);
            exitSubMenuItem.Text = "exit";
            // 
            // settingsMenuItem
            // 
            settingsMenuItem.Name = "settingsMenuItem";
            settingsMenuItem.Size = new Size(60, 20);
            settingsMenuItem.Text = "settings";
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new Size(50, 20);
            aboutMenuItem.Text = "about";
            // 
            // lblActualImageFilePath
            // 
            lblActualImageFilePath.AutoSize = true;
            lblActualImageFilePath.Location = new Point(0, 24);
            lblActualImageFilePath.Name = "lblActualImageFilePath";
            lblActualImageFilePath.Size = new Size(38, 15);
            lblActualImageFilePath.TabIndex = 2;
            lblActualImageFilePath.Text = "label1";
            // 
            // Viewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblActualImageFilePath);
            Controls.Add(PicBx);
            Controls.Add(menu);
            MainMenuStrip = menu;
            Name = "Viewer";
            Text = "Picture viewer";
            FormClosing += Viewer_FormClosing;
            ResizeEnd += Viewer_ResizeEnd;
            LocationChanged += Viewer_LocationChanged;
            KeyDown += Viewer_KeyDown;
            KeyPress += Viewer_KeyPress;
            ((System.ComponentModel.ISupportInitialize)PicBx).EndInit();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PicBx;
        private MenuStrip menu;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem openSubMenuItem;
        private ToolStripMenuItem exitSubMenuItem;
        private ToolStripMenuItem settingsMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private Label lblActualImageFilePath;
    }
}
