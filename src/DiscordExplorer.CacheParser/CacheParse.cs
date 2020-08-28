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

			DiskCache.Index index = IndexParse.parse(indexFile);

			// Debug 
			Console.WriteLine();
			BlockFileParse.parse(validBlockFiles[0]);

			/* Parsing an CacheAddr
			UInt32 addr = (UInt32)index.table[0];
			Console.WriteLine($"Address:\t0x{addr:x}");
			uint type = addr >> 32;
			addr &= 0x0fffffff;
			uint reserved = (addr >> 24) >> 2;
			uint blockSize = (addr >> 24) & 0x3;
			uint fileNum = (addr >> 16) & 0xff;
			uint blockNum = addr & 0xffff;
			Console.WriteLine($"reserved:\t0x{reserved:x}");
			Console.WriteLine($"blockSize:\t0x{blockSize:x}");
			Console.WriteLine($"fileNum:\t0x{fileNum:x}");
			Console.WriteLine($"blockNum:\t0x{blockNum:x}");
			*/

        }
    }
}
