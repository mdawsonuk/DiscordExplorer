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
        [OneTimeSetUp]
        public static void Setup()
        {
            Directory.CreateDirectory("temp_output");
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            Directory.Delete("temp_output", true);
        }

        [Test(Author = "mdawsonuk")]
        public static void GroupMessagesByChannelID()
        {
            Directory.CreateDirectory("temp_output");

            var messages = new List<DiscordMessage>()
            {
                new DiscordMessage(0L, 0L, 0L, ""),
                new DiscordMessage(0L, 1L, 0L, ""),
            };

            CsvHandler.WriteMessages("temp_output", messages);

            Assert.That(Directory.GetFiles(Path.Combine("temp_output", "messages"), "*.csv").Length, Is.EqualTo(2), "There are two unique channel IDs, so two CSV files should be created");
        }
    }
}