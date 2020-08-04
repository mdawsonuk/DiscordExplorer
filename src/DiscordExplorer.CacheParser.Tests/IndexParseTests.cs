using NUnit.Framework;
using System.IO;

namespace DiscordExplorer.CacheParser
{
    [TestFixture]
    [TestOf(typeof(IndexParse))]
    public static class IndexParseTests
    {
        [Test(Author = "mdawsonuk")]
        public static void ParseNonExistingFile()
        {
            Assert.That(() => IndexParse.parse("invalid_file"), Throws.InstanceOf<FileNotFoundException>());
        }

        [Test(Author = "mdawsonuk")]
        public static void ParseInvalidFile()
        {
            using (StreamWriter writer = new StreamWriter("test_index"))
            {
                // Incorrect file header
                writer.Write(0xC103CAC4);
            }
            Assert.That(() => IndexParse.parse("test_index"), Throws.InstanceOf<FileFormatException>());

            File.Delete("test_index");
        }
    }
}