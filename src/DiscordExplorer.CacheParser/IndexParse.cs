using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace DiscordExplorer.CacheParser
{
    /* Constants / Structures taken from: 
	 * https://src.chromium.org/viewvc/chrome/trunk/src/net/disk_cache/blockfile/disk_format.h?view=markup
	 * https://src.chromium.org/viewvc/chrome/trunk/src/net/disk_cache/blockfile/disk_format_base.h?view=markup
	 */
    using CacheAddr = UInt32;
    internal class disk_cache {

		// Index constants
        internal const Int32 kIndexTablesize = 0x10000;
        internal const UInt32 kIndexMagic = 0xC103CAC3;
        internal const UInt32 kCurrentVersion = 0x20000;  // Version 2.0.

		// Block Constants
		internal const UInt32 kBlockVersion2 = 0x20000;  // Version 2.0.
		internal const UInt32 kBlockCurrentVersion = 0x30000;  // Version 3.0.

		internal const UInt32 kBlockMagic = 0xC104CAC3;
		internal const Int32 kBlockHeaderSize = 8192;  // Two Pages: almost 64k entries
		internal const Int32 kMaxBlocks = (kBlockHeaderSize - 80) * 8;
		internal const Int32 kNumExtraBlocks = 1024;  // How fast files grow.

        [StructLayout(LayoutKind.Sequential)]
        internal struct LruData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            internal Int32[]		pad1;
            internal Int32			filled;          // Flag to tell when we filled the cache.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            internal Int32[]		sizes;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            internal CacheAddr[]	heads;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            internal CacheAddr[]	tails;
            internal CacheAddr  	transaction;     // In-flight operation target.
            internal Int32       	operation;       // Actual in-flight operation.
            internal Int32       	operation_list;  // In-flight operation list.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            internal Int32[]     	pad2;
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct IndexHeader
        {
            internal UInt32		magic;        // Magic number
            internal UInt32		version;      // Version number
            internal Int32		num_entries;  // Number of entries currently stored.
            internal Int32		num_bytes;    // Total size of the stored data.
            internal Int32		last_file;    // Last external file created.
            internal Int32		this_id;      // Id for all entries being changed (dirty flag).
            internal CacheAddr	stats;        // Storage for usage data.
            internal Int32		table_len;    // Actual size of the table (0 == kIndexTablesize).
            internal Int32		crash;        // Signals a previous crash.
            internal Int32		experiment;   // Id of an ongoing test.
            internal UInt64		create_time;  // Creation time for this set of files
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
            internal Int32[]	pad;          // pad out to 256 bytes
            internal LruData	lru;          // Eviction control data.
		}; 

		[StructLayout(LayoutKind.Sequential)]
		internal struct Index
		{
			internal IndexHeader	header;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = kIndexTablesize)]
			internal CacheAddr[]	table;			
		};

		[StructLayout(LayoutKind.Sequential)]
		internal struct BlockFileHeader
		{
			internal UInt32			magic;
			internal UInt32			version;
			internal Int16			this_file;		// Index of this file.
			internal Int16			next_file;		// Next file when this one is full.
			internal Int32			entry_size;		// Size of the blocks of this file. 
			internal Int32			num_entries;	// Number of stored entries.
			internal Int32			max_entries;	// Current maximum number of entries.
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
			internal Int32[]		empty;			// Counters of empty entries for each type.
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
			internal Int32[]		hints;			// Last used position for each entry type.
			internal volatile Int32	updating;		// Keep track of updates to the header.
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
			internal Int32[] 		user;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = (kMaxBlocks / 32))]
			internal Int32[]		allocation_map;	// Bitmap to track used blocks on a block-file
		};
	}

    public static class IndexParse
    {
   
        public static T ByteToType<T>(BinaryReader reader)
        {
            byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(T)));

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();

            return theStructure;
        }
	
		public static DateTime ConvertWebkitTime(ulong timestamp)
		{
			TimeSpan time = TimeSpan.FromMilliseconds((double)(timestamp/1000));
			DateTime date = new DateTime(1601, 1, 1) + time;
			return date;
		}

        public static void parse(string indexFile)
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
                var index = ByteToType<disk_cache.Index>(br);

                // check the magic value
                //index.magic = br.ReadUInt32();

                if (index.header.magic != disk_cache.kIndexMagic)
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
                Console.WriteLine($"create_time: {ConvertWebkitTime(index.header.create_time).ToString(System.Globalization.CultureInfo.InvariantCulture)}");

				
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
				List<CacheAddr> valid_addresses = new List<CacheAddr>();
				for (int i = 0; i < index.table.Length; i++) {
					if (index.table[i] != 0)
						valid_addresses.Add(index.table[i]);
				}
				Console.WriteLine($"Cache Addresses [{valid_addresses.Count} valid]:");
				Console.WriteLine($"\tvalid_addresses[0]:\t0x{valid_addresses[0]:x}");
				Console.WriteLine("\t...");
				Console.WriteLine($"\tvalid_addresses[{valid_addresses.Count-1}]:\t0x{valid_addresses[valid_addresses.Count-1]:x}");



            }
        }
    }
}
