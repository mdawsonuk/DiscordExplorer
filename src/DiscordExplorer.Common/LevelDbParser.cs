using System;
using System.Diagnostics;
using System.IO;

namespace DiscordExplorer.Common
{
    public class LevelDbParser
    {
        /// <summary>
        /// User ID of the Local User
        /// </summary>
        public long LocalUserID { get; private set; }

        /// <summary>
        /// Email Address of the local user
        /// </summary>
        public string LocalUserEmail { get; private set; }

        /// <summary>
        /// Searches made by the local user in servers/guilds
        /// </summary>
        public string UserSearches { get; private set; }

        /// <summary>
        /// Draft messages by the local user
        /// </summary>
        public string UserDrafts { get; private set; }

        /// <summary>
        /// The recently used emojis by the local user
        /// </summary>
        public string UserEmojis { get; private set; }

        /// <summary>
        /// Recently played games
        /// </summary>
        public string GameStore { get; private set; }

        /// <summary>
        /// Token for the user
        /// </summary>
        public string UserToken { get; private set; }

        public string GifFavourites { get; private set; }

        public string SelectedChannelStore { get; private set; }

        #region Timestamp Evidence

        public long LastVoiceFeedback { get; private set; }

        public long LastNonRequiredUpdateShown { get; private set; }

        public long LastHiddenChannelNotice { get; private set; }

        public DateTime LastChangeLogDate { get; private set; }

        #endregion

        /// <summary>
        /// Creates a parser for the given LevelDB directory
        /// </summary>
        /// <param name="directory"></param>
        public LevelDbParser(string directory)
        {
            LoadValues(directory);
        }

        private void LoadValues(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException($"Directory {directory} not found");
            }

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c DiscordExplorer.LevelDBParser.exe \"" + directory + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                }
            };
            Console.WriteLine(Environment.CurrentDirectory);
            proc.Start();
            string output = proc.StandardOutput.ReadToEnd();
            string[] lines = output.Split("\n");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].EndsWith("user_id_cache"))
                {
                    LocalUserID = long.Parse(lines[i + 1][1..^1]);
                }
                if (lines[i].EndsWith("email_cache"))
                {
                    LocalUserEmail = lines[i + 1][1..^1];
                }
                if (lines[i].EndsWith("DraftStore"))
                {
                    UserDrafts = lines[i + 1];
                }
                if (lines[i].EndsWith("EmojiStore"))
                {
                    UserEmojis = lines[i + 1];
                }
                if (lines[i].EndsWith("SearchStore"))
                {
                    UserSearches = lines[i + 1];
                }
                if (lines[i].EndsWith("SearchStore"))
                {
                    GameStore = lines[i + 1];
                }
                if (lines[i].EndsWith("token"))
                {
                    UserToken = lines[i + 1][1..^1];
                }
                if (lines[i].EndsWith("GIFFavoritesStore"))
                {
                    GifFavourites = lines[i + 1];
                }
                if (lines[i].EndsWith("SelectedChannelStore"))
                {
                    SelectedChannelStore = lines[i + 1];
                }
                if (lines[i].EndsWith("lastVoiceFeedback"))
                {
                    LastVoiceFeedback = long.Parse(lines[i + 1]);
                }
                if (lines[i].EndsWith("lastNonRequiredUpdateShown"))
                {
                    LastNonRequiredUpdateShown = long.Parse(lines[i + 1]);
                }
                if (lines[i].EndsWith("lastHiddenChannelNotice"))
                {
                    LastHiddenChannelNotice = long.Parse(lines[i + 1]);
                }
                if (lines[i].EndsWith("lastChangeLogDate"))
                {
                    LastChangeLogDate = DateTime.Parse(lines[i + 1][1..^1]);
                }
            }
        }
    }
}
