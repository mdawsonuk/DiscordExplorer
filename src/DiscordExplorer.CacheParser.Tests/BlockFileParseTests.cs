using NUnit.Framework;
using System.IO;

namespace DiscordExplorer.CacheParser.Tests
{
    [TestFixture]
    [TestOf(typeof(BlockFileParse))]
    public static class BlockFileParseTests
    {
        [Test(Author = "mdawsonuk")]
        public static void ParseNonExistingBlockFile()
        {
            Assert.That(() => BlockFileParse.parseHeader("non_existing_block_file"), Throws.InstanceOf<FileNotFoundException>(), "Trying to parse a header for a file that doesn't exist should throw a FileNotFoundException");
        }

        [Test(Author = "mdawsonuk")]
        public static void ParseInvalidBlockFile()
        {
            using (StreamWriter writer = new StreamWriter("test_data_file"))
            {
                for (int i = 0; i < 1000000; i++)
                {
                    // Incorrect file header
                    writer.Write(0x00);
                }
            }

            Assert.That(() => BlockFileParse.parseHeader("test_data_file"), Throws.InstanceOf<FileFormatException>());

            File.Delete("test_data_file");
        }
    }
}
