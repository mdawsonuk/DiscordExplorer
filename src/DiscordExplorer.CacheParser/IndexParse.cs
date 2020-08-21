using System;
using System.IO;
using System.Collections.Generic;

namespace DiscordExplorer.CacheParser
{
    using CacheAddr = UInt32;
    internal static class IndexParse
    {
        internal static void parse(string indexFile)
        {
            Console.WriteLine($"Parsing index file: '{indexFile}'");

            /* check whether the file exists and throw an exception otherwise */
            if (!File.Exists(indexFile))
            {
                throw new FileNotFoundException($"Couldn't open index file.");
            }

            /* parse the index file */
            using (BinaryReader br = new BinaryReader(File.Open(indexFile, FileMode.Open, FileAccess.Read)))
            {
				DiskCache.Index index = new DiskCache.Index(new DiskCache.IndexHeader(), new List<CacheAddr>());
                index.header = Util.ByteToType<DiskCache.IndexHeader>(br);

                if (index.header.magic != DiskCache.kIndexMagic)
                {
                    throw new FileFormatException($"Index file parse failed - Invalid Magic Number");
                }

                // debug output
                Console.WriteLine($"magic:       0x{index.header.magic:x}");
                Console.WriteLine($"version:     {index.header.version / 10000}.{(index.header.version / 100) % 100}.{index.header.version % 100}");
                Console.WriteLine($"num_entries: {index.header.num_entries}");
                Console.WriteLine($"num_bytes:   {index.header.num_bytes / (1_000_000)}Mb");
                Console.WriteLine($"last_file:   {index.header.last_file}");
                Console.WriteLine($"this_id:     {index.header.this_id}");
                Console.WriteLine($"stats:       {index.header.stats}");
                Console.WriteLine($"table_len:   {index.header.table_len}");
                Console.WriteLine($"crash:       {index.header.crash}");
                Console.WriteLine($"experiment:  {index.header.experiment}");
                Console.WriteLine($"create_time: {Util.ConvertWebkitTime(index.header.create_time).ToString(System.Globalization.CultureInfo.InvariantCulture)}");

				
                // lru data
                Console.WriteLine();
				Console.WriteLine($"lru.filled: {index.header.lru.filled}");
                Console.WriteLine("lru.sizes:");
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine($"\tlru.sizes[{i}]: 0x{index.header.lru.sizes[i]:x}");
                }
                Console.WriteLine("lru.heads:");
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine($"\tlru.heads[{i}]: 0x{index.header.lru.heads[i]:x}");
                }
                Console.WriteLine("lru.tails:");
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine($"\tlru.tails[{i}]: 0x{index.header.lru.tails[i]:x}");
                }
                Console.WriteLine($"lru.transaction: {index.header.lru.transaction}");
                Console.WriteLine($"lru.operation: {index.header.lru.operation}");
                Console.WriteLine($"lru.operation_list: {index.header.lru.operation_list}");
				
				// Cache Addresses
				Console.WriteLine();
				for (int i = 0; i < index.header.table_len; i++) {
                    CacheAddr addr = br.ReadUInt32();
					if (addr != 0)
						index.table.Add(addr);
				}
				Console.WriteLine($"Cache Addresses [{index.table.Count} valid]:");
				Console.WriteLine($"\tindex.table[0]:\t\t0x{index.table[0]:x}");
				Console.WriteLine("\t...");
				Console.WriteLine($"\tindex.table[{index.table.Count-1}]:\t0x{index.table[index.table.Count-1]:x}");
            }
        }
    }
}
