using Newtonsoft.Json.Linq;
using System.Linq;

namespace DiscordExplorer.Common.Types
{
    public class DiscordMessage
    {
        public long ID { get; private set; }

        public long ChannelID { get; private set; }

        public string Message { get; private set; }

        public long UserID { get; private set; }

        public DiscordUser User
        {
            get
            {
                if (CacheJsonParser.Users.Any(u => u.UserID == UserID))
                {
                    return CacheJsonParser.Users.First(u => u.UserID == UserID);
                }
                return null;
            }
        }

        public DiscordMessage(string json)
        {
            JArray messages = JArray.Parse(json);

            foreach (var message in messages)
            {
                ID = message["id"].ToObject<long>();
                ChannelID = message["channel_id"].ToObject<long>();
                UserID = message["author"]["id"].ToObject<long>();
                Message = message["content"].ToString();
            }
        }
    }
}
