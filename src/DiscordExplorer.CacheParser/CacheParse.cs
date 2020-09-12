using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DiscordExplorer.CacheParser
{
    public class CacheParse
    {
		/// <summary>
		/// Parses the Cache directory at the given path
		/// </summary>
		/// <param name="cacheDir">Path to the cache directory</param>
		/// <returns>Array of HTTP information about the file. This can be used to get a stream to the file contents</returns>
        public static List<DiskCache.HttpInformation> Parse(string cacheDir)
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

			List<DiskCache.HttpInformation> files = new List<DiskCache.HttpInformation>();

			// Iterate every address
			foreach (UInt32 address in index.table)
            {
				DiskCache.CacheAddrStruct addressStruct = DiskCache.ParseCacheAddress(address);
				dynamic addressBlocks = DiskCache.GetBlocks(addressStruct, blockFiles);
				try
                {
					DiskCache.HttpInformation request = new DiskCache.HttpInformation(addressBlocks[0], blockFiles, cacheDir);
					files.Add(request);
				}
				catch (Exception e)
                {
					Console.WriteLine(e.Message);
                }
			}

			/*UInt32 addr = (UInt32)index.table[0];
			DiskCache.CacheAddrStruct addrStruct = DiskCache.ParseCacheAddress(addr);
			dynamic blocks = DiskCache.GetBlocks(addrStruct, blockFiles);

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
			Console.WriteLine($"Payload start  : [{System.Text.Encoding.Default.GetString(payloadStart)}]");*/

			Console.WriteLine();
			Console.WriteLine($"Parsed {files.Count} out of {index.table.Count} from Disk Cache at {cacheDir}");

			var fileInfo = files.Where(x => x.url.Contains("api/") && x.url.Contains("messages?limit=50")).First();
			Console.WriteLine();
			Console.WriteLine(fileInfo.payload_file);
			Console.WriteLine(fileInfo.url);
			var fileStream = fileInfo.GetStream();
			//Console.WriteLine(System.Text.Encoding.Default.GetString(fileStream.ReadBytes(fileInfo.payload_length)));

			return files;
        }
    }
}
