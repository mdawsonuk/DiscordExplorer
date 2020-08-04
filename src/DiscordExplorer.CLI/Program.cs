using System;
using System.IO;
using CommandLine;
using DiscordExplorer.CacheParser;

namespace DiscordExplorer.CLI
{
    public class Options
    {
        [Option('i', "index",
                Required = false,
                HelpText = "Specify the index file to use"
        )]
        public string Index { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o => 
                {
                    string indexFile = o.Index;
                    if (string.IsNullOrEmpty(indexFile)) {
                        indexFile = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                            "discord\\Cache\\index"
                        );
                    }
                    Console.WriteLine($"Current Arguments -> index: {indexFile}");
                    IndexParse.parse(indexFile);
                }
            );
        }
    }
}
