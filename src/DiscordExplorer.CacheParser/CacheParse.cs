using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

			DiskCache.BlockFilesStructure blockFiles = new DiskCache.BlockFilesStructure();
			blockFiles[0] = new DiskCache.BlockFile<DiskCache.RankingsNode>(validBlockFiles[0]);
			blockFiles[1] = new DiskCache.BlockFile<DiskCache.EntryStore>(validBlockFiles[1]);

			/* Parsing an CacheAddr */
			/* TODO
			 * Automate getting addresses
			 * Figure out what to do if CacheAddrStruct.type == 0 (f_xxxx)
			 * */


			UInt32 addr = (UInt32)index.table[0];
			DiskCache.CacheAddrStruct addrStruct = DiskCache.parseCacheAddress(addr, true);
			dynamic blocks = DiskCache.getBlocks(addrStruct, blockFiles);

			Console.WriteLine();
			Console.WriteLine($"Number of blocks read : {blocks.Count}");
			Console.WriteLine($"Type of block read : {blocks[0].GetType()}");
			Console.WriteLine($"EntryStore.key : {System.Text.Encoding.Default.GetString(blocks[0].key)}");

        }
    }
}
