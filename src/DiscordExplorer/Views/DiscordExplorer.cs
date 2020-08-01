using DiscordExplorer.Models;
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

        public DiscordExplorer()
        {
            InitializeComponent();

            MessagesSplitContainer.Paint += PaintHandle;
            ProfilesSplitContainer.Paint += PaintHandle;

            StripStatusLabel.Text = "No cache loaded";
            StripProgressBar.Visible = false;
            TabControl.Visible = false;

            FormClosing += (s, e) =>
            {
                DialogResult confirmClose = MessageBox.Show("Are you sure you want to exit?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (confirmClose == DialogResult.No)
                {
                    e.Cancel = true;
                }
            };
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
            using var indexFile = new OpenFileDialog
            {
                AddExtension = false,
                RestoreDirectory = true,
                Filter = "Cache Index|index|All files|*.*"
            };

            DialogResult result = indexFile.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(indexFile.FileName))
            {
                LoadDiscordFiles(indexFile.FileName);
            }
        }

        private void OnLoadLiveButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("The Discord Cache cannot be parsed while Discord is open. Please quit Discord by right clicking on the tray icon and quitting. Press OK once this has been completed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            LoadDiscordFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Discord\\Cache\\index"));
        }

        private void OnViewGithubClick(object sender, EventArgs e)
        {
            OpenUrl("https://github.com/mdawsonuk/DiscordExplorer/");
        }

        private void OnReportBugClick(object sender, EventArgs e)
        {
            OpenUrl("https://github.com/mdawsonuk/DiscordExplorer/issues/new?labels=bug");
        }

        private void OpenUrl(string url)
        {
            var ps = new ProcessStartInfo(url)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }

        private void OnAboutButtonClick(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void OnExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void LoadDiscordFiles(string path)
        {
            string indexDir = Path.GetDirectoryName(path);
            string[] files = Directory.GetFiles(indexDir);

            StripStatusLabel.Text = string.Format("Loading Cache at {0}", indexDir);
            StripProgressBar.Visible = true;

            Stopwatch timer = new Stopwatch();
            timer.Start();

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

            StripStatusLabel.Text = string.Format("Loaded Cache at {0} ({1}s)", indexDir, timer.Elapsed.TotalSeconds.ToString("0.000"));
            StripProgressBar.Visible = false;
            TabControl.Visible = true;


            MockData();
        }

        private void MockData()
        {
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

            ProfilesData.DataSource = new List<DiscordProfile>()
            {
                new DiscordProfile(dummy, "Test User", "0000", "TestAvatar"),
                new DiscordProfile(dummy, "Test User 2", "0000", "TestAvatar", DateTime.UtcNow.AddDays(-100)),
            };
            ProfilesData.AutoResizeColumns();
        }
    }
}
