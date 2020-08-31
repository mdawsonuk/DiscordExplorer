using System;
using System.IO;
using System.Linq;
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
			blockFiles[3] = new DiskCache.BlockFile<DiskCache.Data3Block>(validBlockFiles[3]);

			/* Parsing an CacheAddr */
			/* TODO
			 * Automate getting addresses
			 * Figure out what to do if CacheAddrStruct.type == 0 (f_xxxx)
			 * */


			UInt32 addr = (UInt32)index.table[0];
			DiskCache.CacheAddrStruct addrStruct = DiskCache.parseCacheAddress(addr);
			dynamic blocks = DiskCache.getBlocks(addrStruct, blockFiles);

			Console.WriteLine();
			Console.WriteLine($"Number of blocks read      : {blocks.Count}");
			Console.WriteLine($"Type of block read         : {blocks[0].GetType()}");
			Console.WriteLine($"EntryStore.creation_time   : {Util.ConvertWebkitTime(blocks[0].creation_time)}");
			Console.WriteLine($"EntryStore.key             : {System.Text.Encoding.Default.GetString(blocks[0].key)}");
			for(int i = 0; i < 4; i ++)
				Console.WriteLine($"EntryStore.data_addr[{i}]\t: 0x{blocks[0].data_addr[i]:x}");

			DiskCache.HttpInformation httpReq = new DiskCache.HttpInformation(blocks[0], blockFiles, cacheDir);
			Console.WriteLine();
			Console.WriteLine($"Filename       : {httpReq.payload_file}");
			Console.WriteLine($"payload offset : 0x{httpReq.payload_offset:x}");
			Console.WriteLine($"payload length : 0x{httpReq.payload_length:x}");
			Console.WriteLine($"Header         : {httpReq.http_header}");

			BinaryReader br = httpReq.GetStream();
			byte[] payloadStart = br.ReadBytes(16);
			Console.WriteLine($"Payload start  : [{System.Text.Encoding.Default.GetString(payloadStart)}]");

        }
    }
}
