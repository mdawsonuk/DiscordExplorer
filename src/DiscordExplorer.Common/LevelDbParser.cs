using LevelDB;
using System.IO;

namespace DiscordExplorer.Common
{
    public class LevelDbParser
    {
        public long LocalUserID { get; private set; }

        public string LocalUserEmail { get; private set; }

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

            var options = new Options
            {
                CreateIfMissing = false,
                ParanoidChecks = true,
            };
            using (var db = new DB(options, directory))
            {
                
            }
        }
    }
}
