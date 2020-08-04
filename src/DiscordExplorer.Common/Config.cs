using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DiscordExplorer.Common
{
    public static class Config
    {
        /// <summary>
        /// Get the Discord cache location for this platform
        /// </summary>
        /// <returns>Path to the Discord cache location</returns>
        public static string GetDiscordCacheLocation()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine("discord", "cache"));
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), Path.Combine(Path.Combine("library", "Application support"), Path.Combine("discord", "cache")));
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine("discord", "cache"));
            }
            throw new NotImplementedException("The current platform is not currently supported");
        }
    }
}
