using DiscordExplorer.Common;
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
                Utils.OpenUrl(e.LinkText);
            };
        }
    }
}
