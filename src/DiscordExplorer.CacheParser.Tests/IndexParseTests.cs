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

        [Test(Author = "saiputravu")]
        public static void ParseInvalidFile()
        {
            using (StreamWriter writer = new StreamWriter("test_index"))
            {
				for (int i = 0; i < 1000000; i++) {
					// Incorrect file header
					writer.Write(0x00);
				}
            }
        	Assert.That(() => IndexParse.parse("test_index"), Throws.InstanceOf<FileFormatException>());

            File.Delete("test_index");
        }
    }
}
