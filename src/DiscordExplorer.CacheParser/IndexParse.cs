using System;
using System.IO;
using System.IO.Packaging;

namespace DiscordExplorer.CacheParser
{
    using CacheAddr = UInt32;
    class disk_cache {
        public const Int32 kIndexTablesize = 0x10000;
        public const UInt32 kIndexMagic = 0xC103CAC3;
        public const UInt32 kCurrentVersion = 0x20000;  // Version 2.0.

        public struct LruData
        {
            Int32[]     pad1; // 2
            Int32       filled;          // Flag to tell when we filled the cache.
            Int32[]     sizes; // 5
            CacheAddr[] heads; // 5
            CacheAddr[] tails; // 5
            CacheAddr   transaction;     // In-flight operation target.
            Int32       operation;       // Actual in-flight operation.
            Int32       operation_list;  // In-flight operation list.
            Int32[]     pad2; // 7
        };

        public struct IndexHeader
        {
            public UInt32 magic;
            public UInt32 version;
            public Int32       num_entries;   // Number of entries currently stored.
            public Int32       num_bytes;     // Total size of the stored data.
            public Int32       last_file;     // Last external file created.
            public Int32       this_id;       // Id for all entries being changed (dirty flag).
            public CacheAddr   stats;         // Storage for usage data.
            public Int32       table_len;     // Actual size of the table (0 == kIndexTablesize).
            public Int32       crash;         // Signals a previous crash.
            public Int32       experiment;    // Id of an ongoing test.
            public UInt64      create_time;   // Creation time for this set of files.
            public Int32[]     pad; // 52
            public LruData     lru;           // Eviction control data.
        };
    }
    public static class IndexParse
    {
        /* Constants taken from: https://chromium.googlesource.com/chromium/chromium/+/master/net/disk_cache/disk_format.h */

        public static void parse(string indexFile)
        {
            Console.WriteLine($"Parsing index file: '{indexFile}'");

            /* check whether the file exists and throw an exception otherwise */
            if (!File.Exists(indexFile))
            {
                throw new FileNotFoundException($"Couldn't open index file.");
            }

            /* parse the index file */
            var index = new disk_cache.IndexHeader();
            using (BinaryReader br = new BinaryReader(File.Open(indexFile, FileMode.Open, FileAccess.Read)))
            {
                /* check the magic value */
                UInt32 magic = br.ReadUInt32();

                if (magic != disk_cache.kIndexMagic) {
                    throw new FileFormatException($"Index file parse failed - Invalid Magic Number");
                }

                /* parse the index file */
                index.magic = magic;
                index.version = br.ReadUInt32();
                index.num_entries = br.ReadInt32();
                index.num_bytes = br.ReadInt32();
                index.last_file = br.ReadInt32();
                index.this_id = br.ReadInt32();
                index.stats = br.ReadUInt32();
                index.table_len = br.ReadInt32();
                index.crash = br.ReadInt32();
                index.experiment = br.ReadInt32();
                index.create_time = br.ReadUInt64();
                
                /*for (int i = 0; i < 52; i++) {

                }*/

                /* debug output */
                Console.WriteLine($"magic:       0x{index.magic:x}");
                Console.WriteLine($"version:     {index.version / 10000}.{(index.version / 100) % 100}.{index.version % 100}");
                Console.WriteLine($"num_entries: {index.num_entries}");
                Console.WriteLine($"num_bytes:   {index.num_bytes}");
                Console.WriteLine($"last_file:   {index.last_file}");
                Console.WriteLine($"this_id:     {index.this_id}");
                Console.WriteLine($"stats:       {index.stats}");
                Console.WriteLine($"table_len:   {index.table_len}");
                Console.WriteLine($"crash:       {index.crash}");
                Console.WriteLine($"experiment:  {index.experiment}");
                Console.WriteLine($"create_time: {index.create_time}");
            }
        }
    }
}