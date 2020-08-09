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
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // Avatar
            // 
            this.Avatar.Image = ((System.Drawing.Image)(resources.GetObject("Avatar.Image")));
            this.Avatar.Location = new System.Drawing.Point(20, 20);
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
            this.Username.Location = new System.Drawing.Point(88, 15);
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
            this.Timestamp.Location = new System.Drawing.Point(184, 20);
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
            this.Message.Location = new System.Drawing.Point(88, 41);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(162, 21);
            this.Message.TabIndex = 1;
            this.Message.Text = "This is a test message.";
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
            this.Name = "DiscordMessage";
            this.Size = new System.Drawing.Size(450, 150);
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label Timestamp;
        private System.Windows.Forms.Label Message;
    }
}
