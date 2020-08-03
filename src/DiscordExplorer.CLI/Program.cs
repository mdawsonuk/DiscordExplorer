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
                    if (o.Index != "") {
                        Console.WriteLine($"Current Arguments: -i {o.Index}");
                        IndexParse.parse(o.Index);
                    }
                }
            );
        }
    }
}
