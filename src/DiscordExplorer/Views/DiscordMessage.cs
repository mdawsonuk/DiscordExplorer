using System.Drawing;
using System.Windows.Forms;

namespace DiscordExplorer.Views
{
    public partial class DiscordMessage : UserControl
    {
        public DiscordMessage()
        {
            InitializeComponent();

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Region = new Region(path);
        }
    }
}
