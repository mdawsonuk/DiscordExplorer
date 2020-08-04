using System.Diagnostics;
using System.Linq;

namespace DiscordExplorer.Common
{
    public static class Utils
    {
        /// <summary>
        /// Checks if Discord is currently running
        /// </summary>
        public static bool IsDiscordRunning()
        {
            return Process.GetProcessesByName("discord").Any();
        }

        /// <summary>
        /// Opens the given URL in the default web browser
        /// </summary>
        /// <param name="url">The URL to open</param>
        public static void OpenUrl(string url)
        {
            var ps = new ProcessStartInfo(url)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }
    }
}
