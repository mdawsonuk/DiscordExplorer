namespace DiscordExplorer.Views
{
    partial class DiscordMessage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscordMessage));
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.Username = new System.Windows.Forms.Label();
            this.Timestamp = new System.Windows.Forms.Label();
            this.Message = new System.Windows.Forms.Label();
            this.MentionedOverlay = new System.Windows.Forms.Panel();
            this.PingBar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.MentionedOverlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // Avatar
            // 
            this.Avatar.Image = ((System.Drawing.Image)(resources.GetObject("Avatar.Image")));
            this.Avatar.Location = new System.Drawing.Point(16, 4);
            this.Avatar.Margin = new System.Windows.Forms.Padding(0);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(40, 40);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Username.ForeColor = System.Drawing.Color.White;
            this.Username.Location = new System.Drawing.Point(88, 2);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(78, 21);
            this.Username.TabIndex = 1;
            this.Username.Text = "Test User";
            // 
            // Timestamp
            // 
            this.Timestamp.AutoSize = true;
            this.Timestamp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Timestamp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.Timestamp.Location = new System.Drawing.Point(192, 6);
            this.Timestamp.Name = "Timestamp";
            this.Timestamp.Size = new System.Drawing.Size(81, 15);
            this.Timestamp.TabIndex = 1;
            this.Timestamp.Text = "Today at 00:00";
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(222)))));
            this.Message.Location = new System.Drawing.Point(88, 24);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(162, 21);
            this.Message.TabIndex = 1;
            this.Message.Text = "This is a test message.";
            // 
            // MentionedOverlay
            // 
            this.MentionedOverlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(250)))), ((int)(((byte)(166)))), ((int)(((byte)(26)))));
            this.MentionedOverlay.Controls.Add(this.PingBar);
            this.MentionedOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MentionedOverlay.Location = new System.Drawing.Point(0, 0);
            this.MentionedOverlay.Name = "MentionedOverlay";
            this.MentionedOverlay.Size = new System.Drawing.Size(450, 48);
            this.MentionedOverlay.TabIndex = 2;
            this.MentionedOverlay.Visible = false;
            // 
            // PingBar
            // 
            this.PingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(166)))), ((int)(((byte)(26)))));
            this.PingBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.PingBar.Location = new System.Drawing.Point(0, 0);
            this.PingBar.Margin = new System.Windows.Forms.Padding(0);
            this.PingBar.Name = "PingBar";
            this.PingBar.Size = new System.Drawing.Size(3, 48);
            this.PingBar.TabIndex = 0;
            this.PingBar.Visible = false;
            // 
            // DiscordMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.Controls.Add(this.Message);
            this.Controls.Add(this.Timestamp);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.Avatar);
            this.Controls.Add(this.MentionedOverlay);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DiscordMessage";
            this.Size = new System.Drawing.Size(450, 48);
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.MentionedOverlay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label Timestamp;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Panel MentionedOverlay;
        private System.Windows.Forms.Panel PingBar;
    }
}
