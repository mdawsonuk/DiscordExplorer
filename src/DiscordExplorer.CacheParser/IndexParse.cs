using System;
using System.IO;

namespace DiscordExplorer.CacheParser
{
    public static class IndexParse
    {
        public static void parse(string indexFile) {
            if (string.IsNullOrEmpty(indexFile)) {
                indexFile = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "discord\\Cache\\index"
                );
            }

            Console.WriteLine($"Parsing index file: '{indexFile}'");
        }
    }
}