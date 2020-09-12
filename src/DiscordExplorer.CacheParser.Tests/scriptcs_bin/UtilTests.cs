using NUnit.Framework;
using System;
using System.Linq;

namespace DiscordExplorer.CacheParser.Tests.scriptcs_bin
{
    [TestFixture]
    [TestOf(typeof(Util))]
    public static class UtilTests
    {
        [TestCase(13242413127000000, 637335363270000000, Author = "mdawsonuk")]
        [TestCase(13116508547000000, 636076317470000000, Author = "mdawsonuk")]
        public static void ConvertWebkitTime(long time, long ticks)
        {
            // Get the target time from the number of ticks
            DateTime targetTime = new DateTime(ticks);
            // Assert that the converted DateTime is equal to the target time
            Assert.That(Util.ConvertWebkitTime((ulong)time), Is.EqualTo(targetTime));
        }

        [TestCase(new byte[] { 0x00, 0x01, 0x02, 0x03 }, 1U, 3U, Author = "mdawsonuk")]
        [TestCase(new byte[] { 0x00, 0x01, 0x02, 0x03 }, 1U, 2U, Author = "mdawsonuk")]
        //[TestCase(new byte[] { 0x00, 0x01, 0x02, 0x03 }, 0U, 2U, Author = "mdawsonuk")]
        public static void SliceByteArray(byte[] array, uint start, uint end)
        {
            byte[] result = Util.SliceByteArray(array, start, end);

            Assert.That(result.Length, Is.EqualTo(end - start + 1));

            Assert.That(result.Contains(array[start]), Is.True);
            Assert.That(result.Contains(array[end]), Is.True);

            if (start > 0)
            {
                Assert.That(result.Contains(array[0]), Is.False);
            }
            if (end < array.Length-1)
            {
                Assert.That(result.Contains(array[^1]), Is.False);
            }
        }
    }
}
