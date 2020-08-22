using DiscordExplorer.Common.Types;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace DiscordExplorer.Common
{
    [TestFixture]
    [TestOf(typeof(CsvHandler))]
    public static class CsvHandlerTests
    {
        private const string OUTPUT = "temp_output";

        [OneTimeSetUp]
        public static void Setup()
        {
            Directory.CreateDirectory(OUTPUT);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            Directory.Delete(OUTPUT, true);
        }

        [Test(Author = "mdawsonuk")]
        public static void GroupMessagesByChannelID()
        {
            var messages = new List<DiscordMessage>()
            {
                new DiscordMessage(0L, 0L, 0L, ""),
                new DiscordMessage(0L, 1L, 0L, ""),
            };

            CsvHandler.WriteMessages(OUTPUT, messages);

            Assert.That(Directory.GetFiles(Path.Combine(OUTPUT, "messages"), "*.csv").Length, Is.EqualTo(2), "There are two unique channel IDs, so two CSV files should be created");
        }

        [Test(Author = "mdawsonuk")]
        public static void WriteMessages()
        {
            var messages = new List<DiscordMessage>()
            {
                new DiscordMessage(0L, 1234L, 0L, ""),
            };

            CsvHandler.WriteMessages(OUTPUT, messages);

            Assert.That(File.Exists(Path.Combine(Path.Combine(OUTPUT, "messages"), "1234.csv")), Is.True, "Calling CsvHandler::WriteMessages with a single message with a Channel ID of 1234 should create 1234.csv");
        }

        [Test(Author = "mdawsonuk")]
        public static void WriteProfiles()
        {
            var profiles = new List<DiscordProfile>
            {
                new DiscordProfile(1L),
            };

            CsvHandler.WriteProfiles(OUTPUT, profiles);

            Assert.That(File.Exists(Path.Combine(OUTPUT, "profiles.csv")), Is.True, "Calling CsvHandler::WriteProfiles should create profiles.csv");
        }
    }
}