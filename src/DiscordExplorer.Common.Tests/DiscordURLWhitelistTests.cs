using NUnit.Framework;
using System;

namespace DiscordExplorer.Common
{
    [TestFixture]
    [TestOf(typeof(DiscordURLWhitelist))]
    public static class DiscordURLWhitelistTests
    {
        [Test(Author = "mdawsonuk")]
        [TestCase("https://cdn.discordapp.com/avatars/123456789012345678/0123456789abcdef01234567890abcde.png?size=256")]
        [TestCase("https://cdn.discordapp.com/avatars/123456789012345678/0123456789abcdef01234567890abcde.webp?size=256")]
        [TestCase("https://cdn.discordapp.com/avatars/123456789012345678/0123456789abcdef01234567890abcde.gif?size=256")]
        [TestCase("https://cdn.discordapp.com/emojis/123456789012345678.png?v=1")]
        [TestCase("https://cdn.discordapp.com/emojis/123456789012345678.gif?v=1")]
        [TestCase("https://cdn.discordapp.com/icons/123456789012345678/a_01234567890abcdef0123456789abcde.webp?size=256")]
        [TestCase("https://cdn.discordapp.com/icons/123456789012345678/a_01234567890abcdef0123456789abcde.gif?size=256")]
        [TestCase("https://images-ext-1.discordapp.net/external/-abcdefghijklmnopqrstuvwxyz_1234567890/https/www.example.com/example.png?width=128&height=64")]
        [TestCase("https://images-ext-2.discordapp.net/external/-abcdefghijklmnopqrstuvwxyz_1234567890/https/www.example.com/example.png?width=128&height=64")]
        [TestCase("https://media.discordapp.net/attachments/123456789012345678/123456789012345678/unknown.png?width=256&height=128")]
        [TestCase("https://cdn.discordapp.com/streams/guild:123456789012345678:123456789012345678/0123456789abcdef01234567890abcde")]
        public static void FileUrls(string url)
        {
            Assert.That(DiscordURLWhitelist.GetCategory(new Uri(url)).HasFlag(EDiscordExplorerCategory.Files), Is.True, "This URL should be a file type");
        }

        [Test(Author = "mdawsonuk")]
        [TestCase("https://discordapp.com/api/v6/users/@me/connections")]
        [TestCase("https://discordapp.com/api/v6/users/@me/billing/subscriptions")]
        [TestCase("https://discordapp.com/api/v6/users/@me/notes/123456789012345678")]
        [TestCase("https://discordapp.com/api/v6/users/@me/affinities/guilds")]
        [TestCase("https://discordapp.com/api/v6/users/@me/affinities/users")]
        public static void LocalUserUrls(string url)
        {
            Assert.That(DiscordURLWhitelist.GetCategory(new Uri(url)).HasFlag(EDiscordExplorerCategory.LocalUser), Is.True, "This URL should be a local user type");
        }

        [Test(Author = "mdawsonuk")]
        [TestCase("https://cdn.discordapp.com/avatars/123456789012345678/0123456789abcdef01234567890abcde.png?size=256")]
        [TestCase("https://cdn.discordapp.com/avatars/123456789012345678/0123456789abcdef01234567890abcde.webp?size=256")]
        [TestCase("https://cdn.discordapp.com/avatars/123456789012345678/0123456789abcdef01234567890abcde.gif?size=256")]
        [TestCase("https://discordapp.com/api/v6/users/123456789012345678/profile")]
        [TestCase("https://discordapp.com/api/v6/users/@me/affinities/users")]
        [TestCase("https://discordapp.com/api/v6/users/@me/notes/123456789012345678")]
        public static void ProfilesUrls(string url)
        {
            Assert.That(DiscordURLWhitelist.GetCategory(new Uri(url)).HasFlag(EDiscordExplorerCategory.Profiles), Is.True, "This URL should be a profiles type");
        }

        [Test(Author = "mdawsonuk")]
        [TestCase("https://cdn.discordapp.com/icons/123456789012345678/a_01234567890abcdef0123456789abcde.webp?size=256")]
        [TestCase("https://cdn.discordapp.com/icons/123456789012345678/a_01234567890abcdef0123456789abcde.gif?size=256")]
        [TestCase("https://discordapp.com/api/v6/channels/123456789012345678/pins")]
        [TestCase("https://discordapp.com/api/v6/users/@me/affinities/guilds")]
        [TestCase("https://discordapp.com/api/v6/guilds/123456789012345678/welcome-screen")]
        [TestCase("https://discordapp.com/api/v6/guilds/123456789012345678/messages/search")]
        public static void ServersUrls(string url)
        {
            Assert.That(DiscordURLWhitelist.GetCategory(new Uri(url)).HasFlag(EDiscordExplorerCategory.Servers), Is.True, "This URL should be a servers type");
        }

        [Test(Author = "mdawsonuk")]
        [TestCase("https://discordapp.com/api/v6/channels/123456789012345678/messages/123456789012345678/reactions/test%F0?limit=100")]
        [TestCase("https://discordapp.com/api/v6/channels/123456789012345678/messages?limit=50&around=123456789012345678")]
        [TestCase("https://discordapp.com/api/v6/channels/123456789012345678/pins")]
        [TestCase("https://discordapp.com/api/v6/invites/abcdefg?with_counts=true")]
        public static void MessagesUrls(string url)
        {
            Assert.That(DiscordURLWhitelist.GetCategory(new Uri(url)).HasFlag(EDiscordExplorerCategory.Messages), Is.True, "This URL should be a messages type");
        }

        [Test(Author = "mdawsonuk")]
        [TestCase("https://api.spotify.com/v1/me")]
        [TestCase("https://best.discord.media/region")]
        [TestCase("https://cdn.discordapp.com/app-assets/")]
        [TestCase("https://discordapp.com/assets/")]
        [TestCase("https://i.scdn.co/image/")]
        [TestCase("https://i.ytimg.com/vi/")]
        [TestCase("https://status.discord.com/")]
        public static void UnknownUrls(string url)
        {
            Assert.That(DiscordURLWhitelist.GetCategory(new Uri(url)), Is.EqualTo(EDiscordExplorerCategory.Unknown), "This URL isn't whitelisted and should return Unknown");
        }
    }
}