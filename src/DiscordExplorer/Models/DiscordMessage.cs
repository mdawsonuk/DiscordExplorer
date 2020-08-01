using System;

namespace DiscordExplorer.Models
{
    public class DiscordMessage
    {
        public long UserID { get; set; }
        public string Username { get; set; }
        public string Discriminator { get; set; }
        public long ChannelID { get; set; }
        public long MessageID { get; set; }
        public string Message { get; set; }
        public bool Pinned { get; set; }
        public bool TTS { get; set; }
        public bool DidMentionEveryone { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime? EditedTimestamp { get; set; }

        public DiscordMessage(long userID, string username, string discriminator, long channelID, long messageID, string message, DateTime timestamp, bool pinned = false, bool tts = false, bool mentionEveryone = false, DateTime? editTimestamp = null)
        {
            UserID = userID;
            Username = username;
            Discriminator = discriminator;
            ChannelID = channelID;
            MessageID = messageID;
            Message = message;
            Timestamp = timestamp;
            Pinned = pinned;
            TTS = tts;
            DidMentionEveryone = mentionEveryone;
            EditedTimestamp = editTimestamp;
        }
    }
}
