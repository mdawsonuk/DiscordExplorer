using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DiscordExplorer.CacheParser
{
    /* Constants / Structures taken from: https://chromium.googlesource.com/chromium/chromium/+/master/net/disk_cache/disk_format.h */
    using CacheAddr = UInt32;
    internal class disk_cache {
        internal const Int32 kIndexTablesize = 0x10000;
        internal const UInt32 kIndexMagic = 0xC103CAC3;
        internal const UInt32 kCurrentVersion = 0x20000;  // Version 2.0.

        [StructLayout(LayoutKind.Sequential)]
        internal struct LruData
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2)]
            internal Int32[]  pad1;
            internal Int32       filled;          // Flag to tell when we filled the cache.
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5)]
            internal Int32[]     sizes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5)]
            internal CacheAddr[] heads;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5)]
            internal CacheAddr[] tails;
            internal CacheAddr   transaction;     // In-flight operation target.
            internal Int32       operation;       // Actual in-flight operation.
            internal Int32       operation_list;  // In-flight operation list.
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7)]
            internal Int32[]     pad2;
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct IndexHeader
        {
            internal UInt32      magic;        // Magic number
            internal UInt32      version;      // Version number
            internal Int32       num_entries;  // Number of entries currently stored.
            internal Int32       num_bytes;    // Total size of the stored data.
            internal Int32       last_file;    // Last external file created.
            internal Int32       this_id;      // Id for all entries being changed (dirty flag).
            internal CacheAddr   stats;        // Storage for usage data.
            internal Int32       table_len;    // Actual size of the table (0 == kIndexTablesize).
            internal Int32       crash;        // Signals a previous crash.
            internal Int32       experiment;   // Id of an ongoing test.
            internal UInt64      create_time;  // Creation time for this set of files
            
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 52)]
            internal Int32[]     pad;          // pad out to 256 bytes
            internal LruData     lru;          // Eviction control data.
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
                var index = ByteToType<disk_cache.IndexHeader>(br);

                // check the magic value
                //index.magic = br.ReadUInt32();

                if (index.magic != disk_cache.kIndexMagic)
                {
                    throw new FileFormatException($"Index file parse failed - Invalid Magic Number");
                }

                // debug output
                Console.WriteLine($"magic:       0x{index.magic:x}");
                Console.WriteLine($"version:     {index.version / 10000}.{(index.version / 100) % 100}.{index.version % 100}");
                Console.WriteLine($"num_entries: {index.num_entries}");
                Console.WriteLine($"num_bytes:   {index.num_bytes / (1_000_000)}Mb");
                Console.WriteLine($"last_file:   {index.last_file}");
                Console.WriteLine($"this_id:     {index.this_id}");
                Console.WriteLine($"stats:       {index.stats}");
                Console.WriteLine($"table_len:   {index.table_len}");
                Console.WriteLine($"crash:       {index.crash}");
                Console.WriteLine($"experiment:  {index.experiment}");
                Console.WriteLine($"create_time: {ConvertWebkitTime(index.create_time).ToString(System.Globalization.CultureInfo.InvariantCulture)}");
                // lru data
                Console.WriteLine($"lru.filled: {index.lru.filled}");
                Console.WriteLine("lru.sizes:");
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine($"\tlru.sizes[{i}]: {index.lru.sizes[i]}");
                }
                Console.WriteLine("lru.heads:");
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine($"\tlru.heads[{i}]: {index.lru.heads[i]}");
                }
                Console.WriteLine("lru.tails:");
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine($"\tlru.tails[{i}]: {index.lru.tails[i]}");
                }
                Console.WriteLine($"lru.transaction: {index.lru.transaction}");
                Console.WriteLine($"lru.operation: {index.lru.operation}");
                Console.WriteLine($"lru.operation_list: {index.lru.operation_list}");

            }
        }
    }
}
