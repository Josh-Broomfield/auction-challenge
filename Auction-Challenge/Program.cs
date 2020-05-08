using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_Challenge
{
    class Program
    {
        static int Main(string[] args)
        {
            //help options
            if (args.Contains("--help") || args.Contains("-h") || args.Contains("-nw") || args.Contains("--no-write"))
            {
                Console.WriteLine("-n or --no-display: Do not display output \n-nw or --no-write: does not write to output.json");
                return 0;
            }

            //getting input.json
            string input = "";
            string curr = "";
            while((curr = Console.ReadLine()) != null)
            {
                input += curr;
            }

            //getting config file
            char slash = Path.DirectorySeparatorChar;
            string root = Path.GetPathRoot(Directory.GetCurrentDirectory());
            string path = $"{root}{slash}auction{slash}";

            string config = File.ReadAllText($"{path}config.json");


            //running the auctions
            AuctionChallenge ac = new AuctionChallenge();

            ac.LoadConfig(config);
            ac.LoadInput(input);
            ac.RunAuctions();

            //writing output to file
            string res = JsonConvert.SerializeObject(ac.AuctionResults, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            if (args.Contains("-nw") || args.Contains("--no-write"))
            {
                System.IO.File.WriteAllText($"{path}output.json", res);
            }

            //optionally write output to console
            if (!(args.Contains("-n") || args.Contains("--no-display")))
            {
                Console.WriteLine(res);
            }

            return 0;
        }
    }
}
