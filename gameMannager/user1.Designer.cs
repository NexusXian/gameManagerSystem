namespace gameMannager
{
    partial class user1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(user1));
            menuStrip1 = new MenuStrip();
            游戏商场ToolStripMenuItem = new ToolStripMenuItem();
            游戏库存ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 游戏商场ToolStripMenuItem, 游戏库存ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(1077, 26);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 游戏商场ToolStripMenuItem
            // 
            游戏商场ToolStripMenuItem.Name = "游戏商场ToolStripMenuItem";
            游戏商场ToolStripMenuItem.Size = new Size(83, 24);
            游戏商场ToolStripMenuItem.Text = "游戏商场";
            游戏商场ToolStripMenuItem.Click += 游戏商场ToolStripMenuItem_Click;
            // 
            // 游戏库存ToolStripMenuItem
            // 
            游戏库存ToolStripMenuItem.Name = "游戏库存ToolStripMenuItem";
            游戏库存ToolStripMenuItem.Size = new Size(83, 24);
            游戏库存ToolStripMenuItem.Text = "游戏库存";
            游戏库存ToolStripMenuItem.Click += 游戏库存ToolStripMenuItem_Click;
            // 
            // user1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1077, 652);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 2, 2, 2);
            Name = "user1";
            Text = "用户主界面";
            Load += user1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 游戏商场ToolStripMenuItem;
        private ToolStripMenuItem 游戏库存ToolStripMenuItem;
    }
}