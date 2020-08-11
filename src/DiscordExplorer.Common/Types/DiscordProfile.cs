using Newtonsoft.Json.Linq;
using System;

namespace DiscordExplorer.Common.Types
{
    public sealed class DiscordProfile
    {
        public long UserID { get; private set; }

        public string Username { get; private set; }

        public string Avatar { get; private set; }

        public string Discriminator { get; private set; }

        public MutualGuild[] MutualGuilds { get; private set; }

        public DiscordConnection[] Connections { get; private set; }

        public DateTime? PremiumSince { get; private set; }

        public DateTime? BoostingSince { get; private set; }

        public DiscordProfile(long id)
        {
            UserID = id;
        }

        /// <summary>
        /// Constructor for a DiscordProfile. Can parse the "author" JSON from a message or the "user" JSON from a profile
        /// </summary>
        /// <param name="json">JSON to parse the data from. Can be a message JSON file or a profile JSON file</param>
        public DiscordProfile(string json)
        {
            JObject discordProfile = JObject.Parse(json);

            if (discordProfile["author"] != null)
            {
                UserID = discordProfile["author"]["id"].ToObject<long>();
                Username = discordProfile["author"]["username"].ToString();
                Avatar = discordProfile["author"]["avatar"].ToString();
                Discriminator = discordProfile["author"]["discriminator"].ToString();
            }
            if (discordProfile["user"] != null)
            {
                UserID = discordProfile["user"]["id"].ToObject<long>();
                Username = discordProfile["user"]["username"].ToString();
                Avatar = discordProfile["user"]["avatar"].ToString();
                Discriminator = discordProfile["user"]["discriminator"].ToString();

                JArray mutualGuilds = (JArray)discordProfile["mutual_guilds"];
                MutualGuilds = new MutualGuild[mutualGuilds.Count];
                for (int i = 0; i < MutualGuilds.Length; i++)
                {
                    MutualGuilds[i] = new MutualGuild(mutualGuilds[i].ToString());
                }

                JArray connections = (JArray)discordProfile["mutual_guilds"];
                Connections = new DiscordConnection[connections.Count];
                for (int i = 0; i < Connections.Length; i++)
                {
                    Connections[i] = new DiscordConnection(connections[i].ToString());
                }

                if (discordProfile["premium_since"].Type != JTokenType.Null)
                {
                    Console.Write(discordProfile["premium_since"].Type);
                    PremiumSince = discordProfile["premium_since"].ToObject<DateTime?>();

                    if (discordProfile["premium_guild_since"].Type != JTokenType.Null)
                    {
                        BoostingSince = discordProfile["premium_guild_since"].ToObject<DateTime?>();
                    }
                }
            }
        }

        public struct MutualGuild
        {
            public long ID { get; private set; }

            public string Nickname { get; private set; }

            public MutualGuild(string json)
            {
                JObject mutualGuild = JObject.Parse(json);
                ID = mutualGuild["id"].ToObject<long>();
                Nickname = mutualGuild["nick"].ToString();
            }
        }

        public struct DiscordConnection
        {
            public string Name { get; private set; }

            public string ID { get; private set; }

            public EConnectionType ConnectionType { get; private set; }

            public bool Verified { get; private set; }

            public DiscordConnection(string json)
            {
                JObject connection = JObject.Parse(json);
                Name = connection["name"].ToString();
                ID = connection["id"].ToString();
                Verified = connection["verified"].ToObject<bool>();
                string type = connection["type"].ToString();
                ConnectionType = type switch
                {
                    "twitch"  => EConnectionType.Twitch,
                    "twitter" => EConnectionType.Twitter,
                    "reddit"  => EConnectionType.Reddit,
                    "steam"   => EConnectionType.Steam,
                    "spotify" => EConnectionType.Spotify,
                    "youtube" => EConnectionType.YouTube,
                    _ => EConnectionType.Unknown,
                };
            }

            /// <summary>
            /// Get a URL to the specified account
            /// </summary>
            /// <returns>A url to the account connected with the Discord account</returns>
            public string GetConnectionUrl()
            {
                return ConnectionType switch
                {
                    EConnectionType.Twitter  => $"https://twitter.com/{Name}",
                    EConnectionType.Reddit   => $"https://reddit.com/user/{Name}",
                    EConnectionType.YouTube  => $"https://youtube.com/channel/{ID}",
                    EConnectionType.Twitch   => $"https://www.twitch.tv/{Name}",
                    EConnectionType.Steam    => $"https://steamcommunity.com/profiles/{ID}",
                    EConnectionType.Spotify  => $"https://open.spotify.com/user/{ID}",
                    EConnectionType.XboxLive => $"https://xboxgamertag.com/search/{Name}",
                    EConnectionType.Github   => $"https://github.com/{Name}",
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

            Unknown = -1,
        }
    }
}
