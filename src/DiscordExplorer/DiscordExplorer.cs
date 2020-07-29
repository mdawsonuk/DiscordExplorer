using System;
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

            //Load += (s, e) => LoadDiscordFiles();

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
        }

        public void LoadDiscordFiles()
        {
            using (var cacheLocation = new FolderBrowserDialog())
            {
                cacheLocation.ShowNewFolderButton = false;
                cacheLocation.Description = "Select Discord Cache Folder";
                cacheLocation.UseDescriptionForTitle = true;
                cacheLocation.SelectedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine("Discord", "Cache"));
                DialogResult result = cacheLocation.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(cacheLocation.SelectedPath))
                {
                    string[] files = Directory.GetFiles(cacheLocation.SelectedPath);

                    MessageBox.Show("Files found: " + files.Length.ToString(), " in Discord Cache");
                }
            }
        }
    }
}
