using System;
using System.IO;
using System.Collections.Generic;

namespace DiscordExplorer.CacheParser
{
    public class CacheParse
    {
        public static void parse(string cacheDir)
        {
            string indexFile = Path.Combine(cacheDir, "index");
			List<string> validBlockFiles = new List<string>();
			

			for (int i = 0; i < 4; i++) 
			{
				if (File.Exists(Path.Combine(cacheDir, $"data_{i}")))
					validBlockFiles.Add(Path.Combine(cacheDir, $"data_{i}"));
			}
            IndexParse.parse(indexFile);

			// Debug 
			Console.WriteLine();
			BlockFileParse.parse(validBlockFiles[0]);
        }
    }
}
