using System;
using System.ComponentModel;

namespace DiscordExplorer.Models
{
    public class DiscordMessage
    {
        public DiscordProfile User { get; set; }

        [DisplayName("Channel ID")]
        public long ChannelID { get; set; }

        public long MessageID = 0L;

        public string Message { get; set; }

        public bool IsPinned = false;

        public string Pinned { get { return IsPinned ? "Yes" : "No"; } }

        public bool IsTTS = false;

        public string TTS { get { return IsTTS ? "Yes" : "No"; } }

        public bool DidMentionEveryone = false;

        [DisplayName("Pinged Everyone")]
        public string PingedEveryone { get { return DidMentionEveryone ? "Yes" : "No"; } }

        public DateTime Timestamp { get; set; }

        [DisplayName("Edited Timestamp")]
        public DateTime? EditedTimestamp { get; set; }

        public DiscordMessage(long userID, string username, string discriminator, long channelID, long messageID, string message, DateTime timestamp, bool pinned = false, bool tts = false, bool mentionEveryone = false, DateTime? editTimestamp = null)
        {
            User = new DiscordProfile(userID, username, discriminator, null);
            ChannelID = channelID;
            MessageID = messageID;
            Message = message;
            Timestamp = timestamp;
            IsPinned = pinned;
            IsTTS = tts;
            DidMentionEveryone = mentionEveryone;
            EditedTimestamp = editTimestamp;
        }
    }
}
