using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DiscordExplorer.Common
{
    public static class DiscordURLWhitelist
    {
        private static readonly Dictionary<string, EDiscordExplorerCategory> UrlCategories = new Dictionary<string, EDiscordExplorerCategory>()
        {
            #region cdn.discordapp.com
            { "https://cdn.discordapp.com/emojis/*.png", EDiscordExplorerCategory.Files },
            { "https://cdn.discordapp.com/emojis/*.gif", EDiscordExplorerCategory.Files },
            { "https://cdn.discordapp.com/avatars/*/*.webp", EDiscordExplorerCategory.Files | EDiscordExplorerCategory.Profiles },
            { "https://cdn.discordapp.com/avatars/*/*.png", EDiscordExplorerCategory.Files | EDiscordExplorerCategory.Profiles },
            { "https://cdn.discordapp.com/avatars/*/*.gif", EDiscordExplorerCategory.Files | EDiscordExplorerCategory.Profiles },
            { "https://cdn.discordapp.com/icons/*/*.webp", EDiscordExplorerCategory.Files | EDiscordExplorerCategory.Servers },
            { "https://cdn.discordapp.com/icons/*/*.gif", EDiscordExplorerCategory.Files | EDiscordExplorerCategory.Servers },
            { "https://cdn.discordapp.com/streams/guild:*:*/*", EDiscordExplorerCategory.Files | EDiscordExplorerCategory.Servers },
            #endregion

            #region discordapp.com/api/v6
            { "https://discordapp.com/api/v6/channels/*/messages/*/reactions/*", EDiscordExplorerCategory.Messages },
            { "https://discordapp.com/api/v6/channels/*/messages", EDiscordExplorerCategory.Messages },
            { "https://discordapp.com/api/v6/channels/*/pins", EDiscordExplorerCategory.Messages | EDiscordExplorerCategory.Servers },
            { "https://discordapp.com/api/v6/guilds/*/welcome-screen", EDiscordExplorerCategory.Servers },
            { "https://discordapp.com/api/v6/guilds/*/messages/search", EDiscordExplorerCategory.Servers },
            { "https://discordapp.com/api/v6/invites/*", EDiscordExplorerCategory.Messages },
            { "https://discordapp.com/api/v6/users/*/profile", EDiscordExplorerCategory.Profiles },
            { "https://discordapp.com/api/v6/users/@me/affinities/guilds", EDiscordExplorerCategory.LocalUser | EDiscordExplorerCategory.Servers},
            { "https://discordapp.com/api/v6/users/@me/affinities/users", EDiscordExplorerCategory.LocalUser | EDiscordExplorerCategory.Profiles},
            { "https://discordapp.com/api/v6/users/@me/connections", EDiscordExplorerCategory.LocalUser },
            { "https://discordapp.com/api/v6/users/@me/billing/subscriptions", EDiscordExplorerCategory.LocalUser },
            { "https://discordapp.com/api/v6/users/@me/notes/*", EDiscordExplorerCategory.LocalUser | EDiscordExplorerCategory.Profiles},
            #endregion

            #region images-ext-*.discordapp.net
            { "https://images-ext-*.discordapp.net/external/*", EDiscordExplorerCategory.Files },
            #endregion

            #region media.discordapp.com
            { "https://media.discordapp.net/attachments/*/*/*", EDiscordExplorerCategory.Files },
            #endregion
        };

        /// <summary>
        /// Get the <see cref="EDiscordExplorerCategory"/> for a URL
        /// </summary>
        /// <param name="url">The full Url from the cache</param>
        /// <returns>EDiscordExplorerCategory type. Unknown if not present on the whitelist</returns>
        public static EDiscordExplorerCategory GetCategory(Uri url)
        {
            foreach (string key in UrlCategories.Keys)
            {
                string regex = WildCardToRegular(key);
                if (Regex.IsMatch(url.GetLeftPart(UriPartial.Path), regex))
                {
                    return UrlCategories[key];
                }
            }
            return EDiscordExplorerCategory.Unknown;
        }

        /// <summary>
        /// Convert from a wildcard string to a regex match string
        /// </summary>
        /// <param name="value">The string containing wildcards</param>
        /// <returns>A regex match formatted string</returns>
        private static string WildCardToRegular(string value)
        {
            return "^" + Regex.Escape(value).Replace("\\*", ".*") + "$";
        }
    }

    [Flags]
    public enum EDiscordExplorerCategory
    {
        LocalUser = 0,
        Messages = 1,
        Files = 2,
        Servers = 4,
        Profiles = 8,

        Unknown = -1,
    }
}
