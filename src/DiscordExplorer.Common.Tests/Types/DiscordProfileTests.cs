using NUnit.Framework;

namespace DiscordExplorer.Common.Types
{
    [TestFixture]
    [TestOf(typeof(DiscordMessage))]
    public static class DiscordProfileTests
    {
        //[Test(Author = "mdawsonuk")]
        [TestCase("{\"user\": {\"id\": \"1\", \"username\": \"Test\", \"avatar\": \"00\", \"discriminator\": \"1234\", \"public_flags\": 640, \"flags\": 640}, \"mutual_guilds\": [], \"connected_accounts\": [], \"premium_since\": null, \"premium_guild_since\": null}",
            1L, "Test", "00", "1234", Author = "mdawsonuk")]
        [TestCase("{\"author\": {\"id\": \"1\", \"username\": \"Test User\", \"avatar\": \"f000\", \"discriminator\": \"1234\", \"public_flags\": 128}}",
            1L, "Test User", "f000", "1234", Author = "mdawsonuk")]
        public static void ParseJson(string json, long id, string username, string avatar, string discriminator)
        {
            DiscordProfile profile = new DiscordProfile(json);

            Assert.That(profile.UserID, Is.EqualTo(id), "The parsed ID should equal the passed ID value");
            Assert.That(profile.Username, Is.EqualTo(username), "The parsed Username should equal the passed Username value");
            Assert.That(profile.Avatar, Is.EqualTo(avatar), "The parsed Avatar should equal the passed Avatar value");
            Assert.That(profile.Discriminator, Is.EqualTo(discriminator), "The parsed Discriminator should equal the passed Discriminator value");
        }

        [TestCase("{\"id\": \"123456789012345678\", \"nick\": \"Test Nickname\"}", 123456789012345678L, "Test Nickname", Author = "mdawsonuk")]
        [TestCase("{\"id\": \"234567890123456789\", \"nick\": null}", 234567890123456789L, "", Author = "mdawsonuk")]
        public static void ParseJsonMutualGuild(string json, long id, string nick)
        {
            DiscordProfile.MutualGuild mutualGuild = new DiscordProfile.MutualGuild(json);

            Assert.That(mutualGuild.ID, Is.EqualTo(id), "The Mutual Guild's ID should be the same as the value passed");
            Assert.That(mutualGuild.Nickname, Is.EqualTo(nick), "The Mutual Guild's nickname should be the same as the value passed");
        }

        [TestCase("{\"type\": \"twitter\", \"id\": \"123456789012345678\", \"name\": \"TestTwitterUser\", \"verified\": true}", DiscordProfile.EConnectionType.Twitter, "123456789012345678", "TestTwitterUser", true, Author = "mdawsonuk")]
        public static void ParseJsonConnection(string json, DiscordProfile.EConnectionType type, string id, string name, bool verified)
        {
            DiscordProfile.DiscordConnection connection = new DiscordProfile.DiscordConnection(json);

            Assert.That(connection.ID, Is.EqualTo(id), "The ID should match the loaded value from the JSON");
            Assert.That(connection.Name, Is.EqualTo(name), "The ID should match the loaded value from the JSON");
            Assert.That(connection.ConnectionType, Is.EqualTo(type), "The Connection Type should match the loaded value from the JSON");
            Assert.That(connection.Verified, Is.EqualTo(verified), "The Verified value should match the loaded value from the JSON");
        }

        [TestCase("{\"type\": \"twitter\", \"id\": \"123456789012345678\", \"name\": \"TestTwitterUser\", \"verified\": true}", "https://twitter.com/TestTwitterUser", Author = "mdawsonuk")]
        [TestCase("{\"type\": \"spotify\", \"id\": \"testspotifyuser\", \"name\": \"Test Spotify User\", \"verified\": true}", "https://open.spotify.com/user/testspotifyuser", Author = "mdawsonuk")]
        public static void GetConnectionUrl(string json, string url)
        {
            DiscordProfile.DiscordConnection connection = new DiscordProfile.DiscordConnection(json);

            Assert.That(connection.GetConnectionUrl(), Is.EqualTo(url), "The URL should match the valid test value");
        }
    }
}
