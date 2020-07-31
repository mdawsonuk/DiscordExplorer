using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DiscordExplorer
{
    public partial class DiscordExplorer : Form
    {
        public class DiscordMessage
        {
            public long UserID { get; set; }
            public string Username { get; set; }
            public string Discriminator { get; set; }
            public long ChannelID { get; set; }
            public long MessageID { get; set; }
            public string Message { get; set; }
            public bool Pinned { get; set; }
            public bool TTS { get; set; }
            public bool DidMentionEveryone { get; set; }
            public DateTime Timestamp { get; set; }
            public DateTime? EditedTimestamp { get; set; }

            public DiscordMessage(long userID, string username, string discriminator, long channelID, long messageID, string message, DateTime timestamp, bool pinned = false, bool tts = false, bool mentionEveryone = false, DateTime? editTimestamp = null)
            {
                UserID = userID;
                Username = username;
                Discriminator = discriminator;
                ChannelID = channelID;
                MessageID = messageID;
                Message = message;
                Timestamp = timestamp;
                Pinned = pinned;
                TTS = tts;
                DidMentionEveryone = mentionEveryone;
                EditedTimestamp = editTimestamp;
            }
        }

        public DiscordExplorer()
        {
            InitializeComponent();

            SplitContainer.Paint += PaintHandle;
        }
        
        private void PaintHandle(object sender, PaintEventArgs p)
        {
            if (sender is SplitContainer splitter)
            {
                if (splitter.Orientation == Orientation.Horizontal)
                {
                    p.Graphics.DrawLine(Pens.DarkGray, 0, splitter.SplitterDistance + (splitter.SplitterWidth / 2), splitter.Width, splitter.SplitterDistance + (splitter.SplitterWidth / 2));
                }
                else
                {
                    p.Graphics.DrawLine(Pens.DarkGray, splitter.SplitterDistance + (splitter.SplitterWidth / 2), 0, splitter.SplitterDistance + (splitter.SplitterWidth / 2), splitter.Height);
                }
            }
        }

        private void OnOpenButtonClick(object sender, EventArgs e)
        {
            LoadDiscordFiles();

            long dummy = 123456789012345678;
            MessagesData.DataSource = new List<DiscordMessage>()
            {
                new DiscordMessage(dummy, "Test User", "0000", dummy, dummy, "@everyone this is a test Message goes here. It can be a really long message but can also be quite short. Obviously, this one is a bit longer than you might expect.\ud83d\ude26", DateTime.UtcNow, mentionEveryone: true),
                new DiscordMessage(dummy, "Test User 2", "0000", dummy, dummy, "\ud83d\ude04", DateTime.UtcNow.AddSeconds(1)),
                new DiscordMessage(dummy, "Test User 3", "0000", dummy, dummy, "\ud83e\udd1e\ud83c\udffb", DateTime.UtcNow.AddSeconds(2), editTimestamp: DateTime.UtcNow.AddSeconds(7)),
                new DiscordMessage(dummy, "Test User 4", "0000", dummy, dummy, "Reee why the ping", DateTime.UtcNow.AddSeconds(5)),
                new DiscordMessage(dummy, "Test User", "0000", dummy, dummy, "Whoops sorry for ping", DateTime.UtcNow.AddSeconds(11), pinned: true),
            };
            MessagesData.AutoResizeColumns();
        }

        public void LoadDiscordFiles()
        {
            using var indexFile = new OpenFileDialog
            {
                AddExtension = false,
                RestoreDirectory = true,
                Filter = "Cache Index|index|All files|*.*"
            };

            DialogResult result = indexFile.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(indexFile.FileName))
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();

                string[] files = Directory.GetFiles(Path.GetDirectoryName(indexFile.FileName));

                int fFiles = 0;
                int dataFiles = 0;
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    if (fileName.StartsWith("f_"))
                    {
                        fFiles += 1;
                    }
                    if (fileName.StartsWith("data_"))
                    {
                        dataFiles += 1;
                    }
                }

                timer.Stop();

                MessageBox.Show(string.Format("Parse Complete!\nParsing took {0} seconds\nData_x files found: {1}\nf_xxxxxx files found: {2}\nOther files found: {3}\nTotal files found: {4}", timer.Elapsed.TotalSeconds.ToString("0.00"), dataFiles, fFiles, files.Length - (fFiles + dataFiles), files.Length), "Parsing Discord Cache", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
