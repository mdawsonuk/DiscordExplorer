using NUnit.Framework;
using System;
using System.IO;

namespace DiscordExplorer.CacheParser
{
    [TestFixture]
    // [TestOf(typeof(IndexParse))]
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

        [TestCase(13242413127000000, 637335363270000000, Author = "mdawsonuk")]
        [TestCase(13116508547000000, 636076317470000000, Author = "mdawsonuk")]
        public static void ConvertWebkitTime(long time, long ticks)
        {
            // Get the target time from the number of ticks
            DateTime targetTime = new DateTime(ticks);
        	// Assert that the converted DateTime is equal to the target time
        	Assert.That(Util.ConvertWebkitTime((ulong)time), Is.EqualTo(targetTime));
        }
    }
}
