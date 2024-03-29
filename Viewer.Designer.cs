﻿namespace Picture_Viewer
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
            MenuItemFile = new ToolStripMenuItem();
            SubMenuItemOpen = new ToolStripMenuItem();
            SubMenuItemExit = new ToolStripMenuItem();
            MenuItemSettings = new ToolStripMenuItem();
            MenuItemHelp = new ToolStripMenuItem();
            SubMenuItemUpdate = new ToolStripMenuItem();
            SubMenuItemAbout = new ToolStripMenuItem();
            lblActualImageFilePath = new Label();
            MenuItemLanguage = new ToolStripMenuItem();
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
            menu.Items.AddRange(new ToolStripItem[] { MenuItemFile, MenuItemLanguage, MenuItemSettings, MenuItemHelp });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(800, 24);
            menu.TabIndex = 1;
            menu.Text = "menuStrip1";
            // 
            // MenuItemFile
            // 
            MenuItemFile.DropDownItems.AddRange(new ToolStripItem[] { SubMenuItemOpen, SubMenuItemExit });
            MenuItemFile.Name = "MenuItemFile";
            MenuItemFile.Size = new Size(35, 20);
            MenuItemFile.Text = "file";
            // 
            // SubMenuItemOpen
            // 
            SubMenuItemOpen.Name = "SubMenuItemOpen";
            SubMenuItemOpen.Size = new Size(180, 22);
            SubMenuItemOpen.Text = "open";
            // 
            // SubMenuItemExit
            // 
            SubMenuItemExit.Name = "SubMenuItemExit";
            SubMenuItemExit.Size = new Size(180, 22);
            SubMenuItemExit.Text = "exit";
            SubMenuItemExit.Click += ExitSubMenuItem_Click;
            // 
            // MenuItemSettings
            // 
            MenuItemSettings.Name = "MenuItemSettings";
            MenuItemSettings.Size = new Size(60, 20);
            MenuItemSettings.Text = "settings";
            // 
            // MenuItemHelp
            // 
            MenuItemHelp.DropDownItems.AddRange(new ToolStripItem[] { SubMenuItemUpdate, SubMenuItemAbout });
            MenuItemHelp.Name = "MenuItemHelp";
            MenuItemHelp.Size = new Size(50, 20);
            MenuItemHelp.Text = "about";
            // 
            // SubMenuItemUpdate
            // 
            SubMenuItemUpdate.Name = "SubMenuItemUpdate";
            SubMenuItemUpdate.Size = new Size(180, 22);
            SubMenuItemUpdate.Text = "update";
            // 
            // SubMenuItemAbout
            // 
            SubMenuItemAbout.Name = "SubMenuItemAbout";
            SubMenuItemAbout.Size = new Size(180, 22);
            SubMenuItemAbout.Text = "about";
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
            // MenuItemLanguage
            // 
            MenuItemLanguage.Name = "MenuItemLanguage";
            MenuItemLanguage.Size = new Size(68, 20);
            MenuItemLanguage.Text = "language";
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
        private ToolStripMenuItem MenuItemFile;
        private ToolStripMenuItem SubMenuItemOpen;
        private ToolStripMenuItem SubMenuItemExit;
        private ToolStripMenuItem MenuItemSettings;
        private ToolStripMenuItem MenuItemHelp;
        private Label lblActualImageFilePath;
        private ToolStripMenuItem SubMenuItemUpdate;
        private ToolStripMenuItem SubMenuItemAbout;
        private ToolStripMenuItem MenuItemLanguage;
    }
}
