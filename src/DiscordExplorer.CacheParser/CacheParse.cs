using System.IO;

namespace DiscordExplorer.CacheParser
{
    public class CacheParse
    {
        public static void parse(string cacheDir)
        {
            string indexFile = Path.Combine(cacheDir, "index");
            IndexParse.parse(indexFile);
        }
    }
}