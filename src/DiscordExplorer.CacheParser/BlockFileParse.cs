using System;
using System.IO;
using System.Collections.Generic;

namespace DiscordExplorer.CacheParser
{
	internal static class BlockFileParse
	{
		internal static DiskCache.BlockFileHeader parseHeader(string blockFile, bool debug = false)
		{
			if (debug)
				Console.WriteLine($"Parsing block file: '{blockFile}'");

			/* check whether the file exists and throw an exception otherwise */
			if (!File.Exists(blockFile))
			{
				throw new FileNotFoundException("Couldn't open block file.");
			}

			/* parse the index file */
			using (BinaryReader br = new BinaryReader(File.Open(blockFile, FileMode.Open, FileAccess.Read)))
			{
				DiskCache.BlockFileHeader header = new DiskCache.BlockFileHeader();
				header = Util.ByteToType<DiskCache.BlockFileHeader>(br);

				if (header.magic != DiskCache.kBlockMagic)
				{
					throw new FileFormatException("Index file parse failed - Invalid Magic Number");	
				}
				
				// debug output
				if (debug)
				{
					Console.WriteLine($"magic:       0x{header.magic:x}");
					Console.WriteLine($"version:     {header.version >> 48}.{header.version & 0xffff}");
					Console.WriteLine($"this_file:   data_{header.this_file}");
					Console.WriteLine($"next_file:   data_{header.next_file}");
					Console.WriteLine($"entry_size:  {header.entry_size}");
					Console.WriteLine($"num_entries: {header.num_entries}");
					Console.WriteLine($"max_entries: {header.max_entries}");
					/* Wrong order but looks cleaner */
					Console.WriteLine($"updating:    {header.updating}");
					Console.WriteLine($"Empty:");
					for (int i = 0; i < header.empty.Length; i++) {
						Console.WriteLine($"\tempty[{i}]: 0x{header.empty[i]:x2}");
					}
					Console.WriteLine($"Hints:");
					for (int i = 0; i < header.hints.Length; i++) {
						Console.WriteLine($"\thints[{i}]: 0x{header.hints[i]:x2}");
					}
					Console.WriteLine($"User:");
					for (int i = 0; i < header.user.Length; i++) {
						Console.WriteLine($"\tuser[{i}]: 0x{header.user[i]:x2}");
					}

					Console.WriteLine();
					Console.WriteLine($"Allocation Map [{header.allocation_map.Length}]");
					Console.WriteLine($"\tallocation_map[0]: 0x{header.allocation_map[0]:x}");
					Console.WriteLine("\t...");
					Console.WriteLine($"\tallocation_map[{header.allocation_map.Length-1}]: 0x{header.allocation_map[header.allocation_map.Length-1]:x}");
				}

				return header;
			}
		}

		internal static void parse(string blockFile, bool debug = false)
		{
			DiskCache.BlockFileHeader header = parseHeader(blockFile);
		}
	}
}


