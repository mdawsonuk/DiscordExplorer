using System;

namespace DiscordExplorer.Models
{
    public class DiscordProfile
    {
        public long UserID { get; private set; }

        public string Username { get; private set; }

        public string Discriminator { get; private set; }

        public string Avatar { get; private set; }

        /// <summary>
        /// The time since the user has had premium - called Nitro by Discord
        /// </summary>
        public DateTime? PremiumSince { get; private set; }

        public MutualGuild[] MutualGuilds { get; private set; } = new MutualGuild[0];

        public DiscordConnection[] Connections { get; private set; } = new DiscordConnection[0];

        public DiscordProfile(long id, string username, string discriminator, string avatar, DateTime? premium = null)
        {
            UserID = id;
            Username = username;
            Discriminator = discriminator;
            Avatar = avatar;
            PremiumSince = premium;
        }
    }

    public struct MutualGuild
    {
        public long ID { get; private set; }

        public string Nickname { get; private set; }

        public MutualGuild(long id, string nick)
        {
            ID = id;
            Nickname = nick;
        }
    }

    public struct DiscordConnection
    {
        public string Name { get; private set; }

        public string ID { get; private set; }

        public EConnectionType ConnectionType { get; private set; }

        public DiscordConnection(string name, string id, EConnectionType type)
        {
            Name = name;
            ID = id;
            ConnectionType = type;
        }

        /// <summary>
        /// Get a URL to the specified account
        /// </summary>
        /// <returns>A url to the account connected with the Discord account</returns>
        public string GetConnectionUrl()
        {
            return ConnectionType switch
            {
                EConnectionType.Twitter => $"https://twitter.com/{Name}",
                EConnectionType.Reddit => $"https://reddit.com/user/{Name}",
                EConnectionType.YouTube => $"https://youtube.com/channel/{ID}",
                EConnectionType.Twitch => $"https://www.twitch.tv/{Name}",
                EConnectionType.Steam => $"https://steamcommunity.com/profiles/{ID}",
                EConnectionType.Spotify => $"https://open.spotify.com/user/{ID}",
                EConnectionType.XboxLive => $"https://xboxgamertag.com/search/{Name}",
                EConnectionType.Github => $"https://github.com/{Name}",
                // TODO: BattleDotNet, Facebook
                _ => throw new NotImplementedException($"Getting a url for a {ConnectionType} profile is not yet supported"),
            };
        }
    }

    public enum EConnectionType
    {
        Twitch = 0,
        YouTube = 1,
        BattleDotNet = 2,
        Steam = 3,
        Reddit = 4,
        Facebook = 5,
        Twitter = 6,
        Spotify = 7,
        XboxLive = 8,
        Github = 9,
    }
}
