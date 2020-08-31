using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DiscordExplorer.CacheParser
{
	internal static class BlockFileParse
	{
		// <summary>
		// Parses the header of a data_n file
		// </summary>
		internal static DiskCache.BlockFileHeader parseHeader(string blockFile, bool debug = false)
		{
			if (debug)
				Console.WriteLine($"Parsing block file: '{blockFile}'");

			/* check whether the file exists and throw an exception otherwise */
			if (!File.Exists(blockFile))
				throw new FileNotFoundException("Couldn't open block file.");

			/* parse the index file */
			using (BinaryReader br = new BinaryReader(File.Open(blockFile, FileMode.Open, FileAccess.Read)))
			{
				DiskCache.BlockFileHeader header = new DiskCache.BlockFileHeader();
				header = Util.ByteToType<DiskCache.BlockFileHeader>(br);

				if (header.magic != DiskCache.kBlockMagic)
					throw new FileFormatException("Block file parse failed - Invalid Magic Number");	
				
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

		// <summary>
		// Parses the blocks in a data_n file
		// Skips over the 0x2000 byte header
		// </summary>
		internal static List<T> parseBlocks<T>(string blockFile, DiskCache.BlockFileHeader header, bool debug = false)
		{
			List<T> blockEntries = new List<T>();

			if (Marshal.SizeOf(typeof(T)) != header.entry_size)
			{
				Console.WriteLine($"Marshal : {Marshal.SizeOf(typeof(T))}");
				Console.WriteLine($"Header  : {header.entry_size}");
			    throw new FileFormatException("Block file parse failed - Invalid entry type");
			}

			if (debug)
			{
				Console.WriteLine($"Entries of size:   [{header.entry_size}]");
				Console.WriteLine($"Number of entries: [{header.num_entries}]");
				Console.WriteLine($"Number of max entries: [{header.max_entries}]");
			}

			FileStream file = File.Open(blockFile, FileMode.Open, FileAccess.Read);
			file.Seek(0x2000, SeekOrigin.Begin);
			using (BinaryReader br = new BinaryReader(file))
			{

				for (int i = 0; i < header.max_entries; i++) 
				{
					T block = (T)Activator.CreateInstance(typeof(T));
					block = Util.ByteToType<T>(br);
					blockEntries.Add(block);
				}
			}

			return blockEntries;
		}
	}
}


