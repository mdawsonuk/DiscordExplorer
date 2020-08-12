using Humanizer;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DiscordExplorer.Views
{
    public partial class DiscordMessage : UserControl
    {
        private readonly PrivateFontCollection pfc = new PrivateFontCollection();

        private readonly Color MentionedColour = Color.FromArgb(13, 250, 166, 26);

        public DiscordMessage(Models.DiscordMessage message)
        {
            InitializeComponent();

            // Load Discord font
            var fontBytes = GetFontResourceBytes(Assembly.GetExecutingAssembly(), "DiscordExplorer.Fonts.Whitney.whitneymedium.otf");
            var fontData = Marshal.AllocCoTaskMem(fontBytes.Length);
            Marshal.Copy(fontBytes, 0, fontData, fontBytes.Length);
            pfc.AddMemoryFont(fontData, fontBytes.Length);
            Username.Font = new Font(pfc.Families[0], Username.Font.Size, Username.Font.Style);
            Timestamp.Font = new Font(pfc.Families[0], Timestamp.Font.Size, Timestamp.Font.Style);
            Message.Font = new Font(pfc.Families[0], Message.Font.Size, Message.Font.Style);

            // Circular avatar
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, Avatar.Width, Avatar.Height);
            Avatar.Region = new Region(path);

            Username.Text = message.User.Username;
            Timestamp.Text = message.Timestamp.Humanize();
            if (message.EditedTimestamp != null)
            {
                Timestamp.Text = "(Edited)";
            }
            Message.Text = message.Message;

            if (message.DidMentionEveryone)
            {
                MentionedOverlay.BackColor = MentionedColour;
                MentionedOverlay.Visible = true;
                PingBar.Visible = true;
            }
        }

        private static byte[] GetFontResourceBytes(Assembly assembly, string fontResourceName)
        {
            var resourceStream = assembly.GetManifestResourceStream(fontResourceName);
            if (resourceStream == null)
                throw new System.Exception(string.Format("Unable to find font '{0}' in embedded resources.", fontResourceName));
            var fontBytes = new byte[resourceStream.Length];
            resourceStream.Read(fontBytes, 0, (int)resourceStream.Length);
            resourceStream.Close();
            return fontBytes;
        }
    }
}
