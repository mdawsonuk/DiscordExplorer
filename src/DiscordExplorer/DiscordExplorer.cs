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
            using var indexFile = new OpenFileDialog
            {
                AddExtension = false,
                RestoreDirectory = true,
                Filter = "Cache Index|index|All files|*.*"
            };

            DialogResult result = indexFile.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(indexFile.FileName))
            {
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

                MessageBox.Show($"Cache found {dataFiles} data_x files and {fFiles} f_xxxxxx files in the cache", "Discord Cache", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
