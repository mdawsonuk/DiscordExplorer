namespace DiscordExplorer
{
    partial class DiscordExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscordExplorer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadLiveCacheMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Strip = new System.Windows.Forms.StatusStrip();
            this.StripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.LocalUser = new System.Windows.Forms.TabPage();
            this.Messages = new System.Windows.Forms.TabPage();
            this.MessagesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.MessagesData = new System.Windows.Forms.DataGridView();
            this.Files = new System.Windows.Forms.TabPage();
            this.Servers = new System.Windows.Forms.TabPage();
            this.Profiles = new System.Windows.Forms.TabPage();
            this.ProfilesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ProfilesData = new System.Windows.Forms.DataGridView();
            this.CacheURLs = new System.Windows.Forms.TabPage();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.Strip.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.Messages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessagesSplitContainer)).BeginInit();
            this.MessagesSplitContainer.Panel1.SuspendLayout();
            this.MessagesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessagesData)).BeginInit();
            this.Profiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilesSplitContainer)).BeginInit();
            this.ProfilesSplitContainer.Panel1.SuspendLayout();
            this.ProfilesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilesData)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1310, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.LoadLiveCacheMenuItem,
            this.toolStripSeparator,
            this.ExitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenMenuItem.Image")));
            this.OpenMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenMenuItem.Size = new System.Drawing.Size(182, 22);
            this.OpenMenuItem.Text = "&Open Cache";
            this.OpenMenuItem.Click += new System.EventHandler(this.OnOpenButtonClick);
            // 
            // LoadLiveCacheMenuItem
            // 
            this.LoadLiveCacheMenuItem.Name = "LoadLiveCacheMenuItem";
            this.LoadLiveCacheMenuItem.Size = new System.Drawing.Size(182, 22);
            this.LoadLiveCacheMenuItem.Text = "Load Live Cache";
            this.LoadLiveCacheMenuItem.Click += new System.EventHandler(this.OnLoadLiveButtonClick);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(179, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ExitMenuItem.Text = "E&xit";
            this.ExitMenuItem.Click += new System.EventHandler(this.OnExitButtonClick);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem4,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem1.Text = "View on GitHub";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.OnViewGithubClick);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem4.Text = "Report a Bug";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.OnReportBugClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutButtonClick);
            // 
            // Strip
            // 
            this.Strip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripStatusLabel,
            this.StripProgressBar});
            this.Strip.Location = new System.Drawing.Point(0, 684);
            this.Strip.Name = "Strip";
            this.Strip.Size = new System.Drawing.Size(1310, 22);
            this.Strip.TabIndex = 1;
            this.Strip.Text = "Strip";
            // 
            // StripStatusLabel
            // 
            this.StripStatusLabel.Name = "StripStatusLabel";
            this.StripStatusLabel.Size = new System.Drawing.Size(95, 17);
            this.StripStatusLabel.Text = "Loading Cache...";
            // 
            // StripProgressBar
            // 
            this.StripProgressBar.Name = "StripProgressBar";
            this.StripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.StripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.StripProgressBar.Value = 20;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.LocalUser);
            this.TabControl.Controls.Add(this.Messages);
            this.TabControl.Controls.Add(this.Files);
            this.TabControl.Controls.Add(this.Servers);
            this.TabControl.Controls.Add(this.Profiles);
            this.TabControl.Controls.Add(this.CacheURLs);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TabControl.Location = new System.Drawing.Point(0, 24);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1310, 660);
            this.TabControl.TabIndex = 0;
            // 
            // LocalUser
            // 
            this.LocalUser.Location = new System.Drawing.Point(4, 24);
            this.LocalUser.Name = "LocalUser";
            this.LocalUser.Padding = new System.Windows.Forms.Padding(3);
            this.LocalUser.Size = new System.Drawing.Size(1302, 632);
            this.LocalUser.TabIndex = 0;
            this.LocalUser.Text = "Local User";
            // 
            // Messages
            // 
            this.Messages.BackColor = System.Drawing.SystemColors.Control;
            this.Messages.Controls.Add(this.MessagesSplitContainer);
            this.Messages.Location = new System.Drawing.Point(4, 24);
            this.Messages.Name = "Messages";
            this.Messages.Padding = new System.Windows.Forms.Padding(3);
            this.Messages.Size = new System.Drawing.Size(1302, 632);
            this.Messages.TabIndex = 0;
            this.Messages.Text = "Messages";
            // 
            // MessagesSplitContainer
            // 
            this.MessagesSplitContainer.BackColor = System.Drawing.Color.Transparent;
            this.MessagesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagesSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.MessagesSplitContainer.Name = "MessagesSplitContainer";
            // 
            // MessagesSplitContainer.Panel1
            // 
            this.MessagesSplitContainer.Panel1.Controls.Add(this.MessagesData);
            this.MessagesSplitContainer.Panel1MinSize = 500;
            this.MessagesSplitContainer.Panel2MinSize = 200;
            this.MessagesSplitContainer.Size = new System.Drawing.Size(1296, 626);
            this.MessagesSplitContainer.SplitterDistance = 899;
            this.MessagesSplitContainer.SplitterIncrement = 5;
            this.MessagesSplitContainer.SplitterWidth = 20;
            this.MessagesSplitContainer.TabIndex = 0;
            this.MessagesSplitContainer.Text = "MessagesSplitContainer";
            // 
            // MessagesData
            // 
            this.MessagesData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MessagesData.BackgroundColor = System.Drawing.Color.White;
            this.MessagesData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessagesData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MessagesData.DefaultCellStyle = dataGridViewCellStyle1;
            this.MessagesData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagesData.Location = new System.Drawing.Point(0, 0);
            this.MessagesData.Name = "MessagesData";
            this.MessagesData.ReadOnly = true;
            this.MessagesData.RowHeadersWidth = 51;
            this.MessagesData.Size = new System.Drawing.Size(899, 626);
            this.MessagesData.TabIndex = 0;
            // 
            // Files
            // 
            this.Files.Location = new System.Drawing.Point(4, 24);
            this.Files.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Files.Name = "Files";
            this.Files.Size = new System.Drawing.Size(1302, 632);
            this.Files.TabIndex = 5;
            this.Files.Text = "Files";
            // 
            // Servers
            // 
            this.Servers.BackColor = System.Drawing.Color.Transparent;
            this.Servers.Location = new System.Drawing.Point(4, 24);
            this.Servers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Servers.Name = "Servers";
            this.Servers.Size = new System.Drawing.Size(1302, 632);
            this.Servers.TabIndex = 3;
            this.Servers.Text = "Servers/Guilds";
            // 
            // Profiles
            // 
            this.Profiles.Controls.Add(this.ProfilesSplitContainer);
            this.Profiles.Location = new System.Drawing.Point(4, 24);
            this.Profiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Profiles.Name = "Profiles";
            this.Profiles.Size = new System.Drawing.Size(1302, 632);
            this.Profiles.TabIndex = 4;
            this.Profiles.Text = "Profiles";
            // 
            // ProfilesSplitContainer
            // 
            this.ProfilesSplitContainer.BackColor = System.Drawing.Color.Transparent;
            this.ProfilesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProfilesSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ProfilesSplitContainer.Name = "ProfilesSplitContainer";
            // 
            // ProfilesSplitContainer.Panel1
            // 
            this.ProfilesSplitContainer.Panel1.Controls.Add(this.ProfilesData);
            this.ProfilesSplitContainer.Panel1MinSize = 500;
            this.ProfilesSplitContainer.Panel2MinSize = 200;
            this.ProfilesSplitContainer.Size = new System.Drawing.Size(1302, 632);
            this.ProfilesSplitContainer.SplitterDistance = 903;
            this.ProfilesSplitContainer.SplitterIncrement = 5;
            this.ProfilesSplitContainer.SplitterWidth = 20;
            this.ProfilesSplitContainer.TabIndex = 0;
            // 
            // ProfilesData
            // 
            this.ProfilesData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ProfilesData.BackgroundColor = System.Drawing.Color.White;
            this.ProfilesData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProfilesData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProfilesData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProfilesData.Location = new System.Drawing.Point(0, 0);
            this.ProfilesData.Name = "ProfilesData";
            this.ProfilesData.ReadOnly = true;
            this.ProfilesData.RowHeadersWidth = 51;
            this.ProfilesData.Size = new System.Drawing.Size(903, 632);
            this.ProfilesData.TabIndex = 0;
            // 
            // CacheURLs
            // 
            this.CacheURLs.Location = new System.Drawing.Point(4, 24);
            this.CacheURLs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CacheURLs.Name = "CacheURLs";
            this.CacheURLs.Size = new System.Drawing.Size(1302, 632);
            this.CacheURLs.TabIndex = 6;
            this.CacheURLs.Text = "Cache URLs";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem3.Text = "Report a Bug";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.OnReportBugClick);
            // 
            // DiscordExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 706);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.Strip);
            this.Controls.Add(this.Menu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.Menu;
            this.MinimumSize = new System.Drawing.Size(698, 396);
            this.Name = "DiscordExplorer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discord Explorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.Strip.ResumeLayout(false);
            this.Strip.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.Messages.ResumeLayout(false);
            this.MessagesSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MessagesSplitContainer)).EndInit();
            this.MessagesSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MessagesData)).EndInit();
            this.Profiles.ResumeLayout(false);
            this.ProfilesSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilesSplitContainer)).EndInit();
            this.ProfilesSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilesData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip Strip;
        private System.Windows.Forms.ToolStripStatusLabel StripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar StripProgressBar;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage Messages;
        private System.Windows.Forms.SplitContainer MessagesSplitContainer;
        private System.Windows.Forms.TabPage LocalUser;
        private System.Windows.Forms.TabPage Files;
        private System.Windows.Forms.TabPage Servers;
        private System.Windows.Forms.TabPage Profiles;
        private System.Windows.Forms.DataGridView MessagesData;
        private System.Windows.Forms.SplitContainer ProfilesSplitContainer;
        private System.Windows.Forms.DataGridView ProfilesData;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TabPage CacheURLs;
        private System.Windows.Forms.ToolStripMenuItem LoadLiveCacheMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    }
}

