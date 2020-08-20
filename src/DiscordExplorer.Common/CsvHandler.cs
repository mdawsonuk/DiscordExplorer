using CsvHelper;
using DiscordExplorer.Common.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DiscordExplorer.Common
{
    /// <summary>
    /// Handles exporting all of the CSV files
    /// </summary>
    public static class CsvHandler
    {
        /// <summary>
        /// Write the array of messages to the given directory as CSV files, with each file being named after the channel ID.
        /// The files will be written to a messages subdirectory
        /// </summary>
        /// <param name="directory">The directory to export to</param>
        /// <param name="messages">The Discord Messages to write to file</param>
        /// <exception cref="DirectoryNotFoundException"/>
        /// <exception cref="ArgumentException"/>
        public static void WriteMessages(string directory, List<DiscordMessage> messages)
        {
            if (messages == null)
            {
                throw new ArgumentNullException("Messages cannot be null");
            }
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException($"Directory {directory} doesn't exist");
            }
            string messagesDir = Path.Combine(directory, "messages");
            if (!Directory.Exists(messagesDir))
            {
                Directory.CreateDirectory(messagesDir);
            }

            long[] channelIDs = messages.Select(x => x.ChannelID).Distinct().ToArray();

            foreach (long channelID in channelIDs)
            {
                var groupedMessages = messages.Where(x => x.ChannelID == channelID);


                using (var writer = new StreamWriter(Path.Combine(messagesDir, $"{channelID}.csv")))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(groupedMessages);
                    }
                }
            }
        }
    }
}
