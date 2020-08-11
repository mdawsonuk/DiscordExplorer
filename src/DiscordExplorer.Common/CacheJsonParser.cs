using DiscordExplorer.Common.Types;
using System;
using System.Collections.Generic;

namespace DiscordExplorer.Common
{
    public class CacheJsonParser
    {
        public static List<DiscordMessage> Messages = new List<DiscordMessage>();

        public static List<DiscordProfile> Users = new List<DiscordProfile>();

        public void Parse(string json, string url)
        {
            var category = DiscordURLWhitelist.GetCategory(new Uri(url));

            switch (category)
            {
                case EDiscordExplorerCategory.Messages:
                    Messages.Add(new DiscordMessage(json));
                    break;
            }
        }
    }
}
