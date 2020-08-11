using NUnit.Framework;
using System.Linq;

namespace DiscordExplorer.Common.Types
{
    [TestFixture]
    [TestOf(typeof(DiscordMessage))]
    public static class DiscordMessageTests
    {
        [TestCase("{\"id\": \"1\", \"type\": 0, \"content\": \"Test Message\", \"channel_id\": \"2\", \"author\": {\"id\": \"3\", \"username\": \"Test User\", \"avatar\": \"f00\", \"discriminator\": \"1234\", \"public_flags\": 128}, \"attachments\": [], \"embeds\": [], \"mentions\": [], \"mention_roles\": [], \"pinned\": false, \"mention_everyone\": false, \"tts\": false, \"timestamp\": \"2020-08-03T23:16:12.538000+00:00\", \"edited_timestamp\": null, \"flags\": 0, \"reactions\": []}",
            1L, 2L, 3L, "Test Message", Author = "mdawsonuk")]
        [TestCase("{\"id\": \"1\", \"type\": 0, \"content\": \"<:emote:123456789012345678>\", \"channel_id\": \"2\", \"author\": {\"id\": \"3\", \"username\": \"User\", \"avatar\": \"f00\", \"discriminator\": \"1234\", \"public_flags\": 128}, \"attachments\": [], \"embeds\": [], \"mentions\": [], \"mention_roles\": [], \"pinned\": false, \"mention_everyone\": false, \"tts\": false, \"timestamp\": \"2020-08-03T23:16:12.538000+00:00\", \"edited_timestamp\": null, \"flags\": 0, \"reactions\": [{\"emoji\": {\"id\": null, \"name\": \"\\ud83d\\udc40\"}, \"count\": 1, \"me\": false}]}",
            1L, 2L, 3L, "<:emote:123456789012345678>", Author = "mdawsonuk")]
        public static void ParseJson(string json, long id, long channelID, long userID, string message)
        {
            DiscordMessage messageObject = new DiscordMessage(json);

            Assert.That(messageObject.ID, Is.EqualTo(id), "The parsed ID should equal the passed ID value");
            Assert.That(messageObject.ChannelID, Is.EqualTo(channelID), "The parsed Channel ID should equal the passed Channel ID value");
            Assert.That(messageObject.UserID, Is.EqualTo(userID), "The parsed User ID should equal the passed User ID value");
            Assert.That(messageObject.Message, Is.EqualTo(message), "The parsed message should equal the passed message value");
        }

        [Test(Author = "mdawsonuk")]
        public static void GetDiscordUserFromMessage()
        {
            CacheJsonParser.Users.Clear();
            string json = "{\"id\": \"0\", \"type\": 0, \"content\": \"\", \"channel_id\": \"0\", \"author\": {\"id\": \"1\", \"username\": \"Test User\", \"avatar\": \"\", \"discriminator\": \"1234\", \"public_flags\": 128}, \"attachments\": [], \"embeds\": [], \"mentions\": [], \"mention_roles\": [], \"pinned\": false, \"mention_everyone\": false, \"tts\": false, \"timestamp\": \"2020-08-03T23:16:12.538000+00:00\", \"edited_timestamp\": null, \"flags\": 0, \"reactions\": []}";
            DiscordProfile user = new DiscordProfile(json);

            CacheJsonParser.Users.Add(user);
            DiscordMessage messageObject = new DiscordMessage(json);

            Assert.That(messageObject.User, Is.EqualTo(user), "Retrieving a user from a User ID lookup should return the first DiscordUser object with the same ID");
        }

        [Test(Author = "mdawsonuk")]
        public static void ParseMessages()
        {
            string json = "[{\"id\": \"1\", \"type\": 0, \"content\": \"Test Message\", \"channel_id\": \"2\", \"author\": {\"id\": \"3\", \"username\": \"Test User\", \"avatar\": \"f00\", \"discriminator\": \"1234\", \"public_flags\": 128}, \"attachments\": [], \"embeds\": [], \"mentions\": [], \"mention_roles\": [], \"pinned\": false, \"mention_everyone\": false, \"tts\": false, \"timestamp\": \"2020-08-01T00:00:00.000+00:00\", \"edited_timestamp\": null, \"flags\": 0, \"reactions\": []}, {\"id\": \"2\", \"type\": 0, \"content\": \"Test Message\", \"channel_id\": \"2\", \"author\": {\"id\": \"3\", \"username\": \"Test User\", \"avatar\": \"f00\", \"discriminator\": \"1234\", \"public_flags\": 128}, \"attachments\": [], \"embeds\": [], \"mentions\": [], \"mention_roles\": [], \"pinned\": false, \"mention_everyone\": false, \"tts\": false, \"timestamp\": \"2020-08-01T00:00:00.00+00:00\", \"edited_timestamp\": null, \"flags\": 0, \"reactions\": []}]";
            var messages = DiscordMessage.ParseMessages(json);
            Assert.That(messages.Any(x => x.ID == 1L), Is.True, "Should contain a message with the ID 1");
            Assert.That(messages.Any(x => x.ID == 2L), Is.True, "Should contain a message with the ID 2");
        }
    }
}
