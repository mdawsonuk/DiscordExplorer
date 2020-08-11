using System;
using System.ComponentModel;

namespace DiscordExplorer.Models
{
    public class DiscordProfile
    {
        public Common.Types.DiscordProfile Profile = null;

        [DisplayName("User ID")]
        public long UserID { get; private set; }

        public string Username { get; private set; }

        public string Discriminator { get; private set; }

        public string Avatar { get; private set; }

        /// <summary>
        /// The time since the user has had premium - called Nitro by Discord
        /// </summary>
        [DisplayName("Premium Since")]
        public DateTime? PremiumSince { get; private set; }

        public DiscordProfile(long id, string username, string discriminator, string avatar, DateTime? premium = null)
        {
            UserID = id;
            Username = username;
            Discriminator = discriminator;
            Avatar = avatar;
            PremiumSince = premium;
        }

        public override string ToString()
        {
            return $"{Username}#{Discriminator}";
        }
    }
}
