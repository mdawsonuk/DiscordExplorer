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
            //var index = new disk_cache.IndexHeader();
            using (BinaryReader br = new BinaryReader(File.Open(indexFile, FileMode.Open, FileAccess.Read)))
            {
                var indexHeader = Util.ByteToType<DiskCache.IndexHeader>(br);

                if (indexHeader.magic != DiskCache.kIndexMagic)
                {
                    throw new FileFormatException($"Index file parse failed - Invalid Magic Number");
                }

                // debug output
                Console.WriteLine($"magic:       0x{indexHeader.magic:x}");
                Console.WriteLine($"version:     {indexHeader.version / 10000}.{(indexHeader.version / 100) % 100}.{indexHeader.version % 100}");
                Console.WriteLine($"num_entries: {indexHeader.num_entries}");
                Console.WriteLine($"num_bytes:   {indexHeader.num_bytes / (1_000_000)}Mb");
                Console.WriteLine($"last_file:   {indexHeader.last_file}");
                Console.WriteLine($"this_id:     {indexHeader.this_id}");
                Console.WriteLine($"stats:       {indexHeader.stats}");
                Console.WriteLine($"table_len:   {indexHeader.table_len}");
                Console.WriteLine($"crash:       {indexHeader.crash}");
                Console.WriteLine($"experiment:  {indexHeader.experiment}");
                Console.WriteLine($"create_time: {Util.ConvertWebkitTime(indexHeader.create_time).ToString(System.Globalization.CultureInfo.InvariantCulture)}");

				
                // lru data
                Console.WriteLine();
				Console.WriteLine($"lru.filled: {indexHeader.lru.filled}");
                Console.WriteLine("lru.sizes:");
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine($"\tlru.sizes[{i}]: 0x{indexHeader.lru.sizes[i]:x}");
                }
                Console.WriteLine("lru.heads:");
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine($"\tlru.heads[{i}]: 0x{indexHeader.lru.heads[i]:x}");
                }
                Console.WriteLine("lru.tails:");
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine($"\tlru.tails[{i}]: 0x{indexHeader.lru.tails[i]:x}");
                }
                Console.WriteLine($"lru.transaction: {indexHeader.lru.transaction}");
                Console.WriteLine($"lru.operation: {indexHeader.lru.operation}");
                Console.WriteLine($"lru.operation_list: {indexHeader.lru.operation_list}");
				
				// Cache Addresses
				Console.WriteLine();
				List<CacheAddr> valid_addresses = new List<CacheAddr>();
				for (int i = 0; i < indexHeader.table_len; i++) {
                    CacheAddr addr = br.ReadUInt32();
					if (addr != 0)
						valid_addresses.Add(addr);
				}
				Console.WriteLine($"Cache Addresses [{valid_addresses.Count} valid]:");
				Console.WriteLine($"\tvalid_addresses[0]:\t0x{valid_addresses[0]:x}");
				Console.WriteLine("\t...");
				Console.WriteLine($"\tvalid_addresses[{valid_addresses.Count-1}]:\t0x{valid_addresses[valid_addresses.Count-1]:x}");
            }
        }
    }
}
