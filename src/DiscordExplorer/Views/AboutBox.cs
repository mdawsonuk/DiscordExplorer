using System.Diagnostics;
using System.Windows.Forms;

namespace DiscordExplorer
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            textBoxDescription.LinkClicked += (s, e) =>
            {
                var ps = new ProcessStartInfo(e.LinkText)
                {
                    UseShellExecute = true,
                    Verb = "open"
                };
                Process.Start(ps);
            };
        }
    }
}
