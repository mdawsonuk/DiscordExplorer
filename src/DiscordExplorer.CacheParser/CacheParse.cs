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

			DiskCache.BlockFileHeader header = BlockFileParse.parseHeader(validBlockFiles[1]);
			List<DiskCache.EntryStore> entries = BlockFileParse.parseBlocks<DiskCache.EntryStore>(validBlockFiles[1], header);

			/* Parsing an CacheAddr */
			/* TODO
			 * Debug in BlockFileParse.parseBlocks
			 * Automate getting addresses
			 * Load all the headers and entries, and use CacheAddrStruct.fileNumber to determine which to use
			 * Figure out what to do if CacheAddrStruct.type == 0 (f_xxxx)
			 * */
			UInt32 addr = (UInt32)index.table[0];
			DiskCache.CacheAddrStruct addrStruct = DiskCache.parseCacheAddress(addr, true);
			Console.WriteLine($"EntryStore.hash: 0x{entries[addrStruct.blockNumber].hash:x}");
			Console.WriteLine($"EntryStore.next: 0x{entries[addrStruct.blockNumber].next:x}");
			Console.WriteLine($"EntryStore.key: [{System.Text.Encoding.Default.GetString(entries[addrStruct.blockNumber].key)}]");
        }
    }
}
