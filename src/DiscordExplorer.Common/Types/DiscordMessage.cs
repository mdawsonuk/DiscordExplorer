using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DiscordExplorer.Common.Types
{
    public sealed class DiscordMessage
    {
        public long ID { get; private set; }

        public long ChannelID { get; private set; }

        public string Message { get; private set; }

        public long UserID { get; private set; }

        public DiscordProfile User
        {
            get
            {
                return CacheJsonParser.Users.FirstOrDefault(u => u.UserID == UserID);
            }
        }

        public DiscordMessage(string json)
        {
            JObject message = JObject.Parse(json);
            ID = message["id"].ToObject<long>();
            ChannelID = message["channel_id"].ToObject<long>();
            UserID = message["author"]["id"].ToObject<long>();
            Message = message["content"].ToString();
        }

        public static List<DiscordMessage> ParseMessages(string json)
        {
            List<DiscordMessage> discordMessages = new List<DiscordMessage>();
            JArray messages = JArray.Parse(json);

            foreach (var message in messages)
            {
                discordMessages.Add(new DiscordMessage(message.ToString()));
            }

            return discordMessages;
        }
    }
}
