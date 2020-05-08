using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_Challenge
{
    public class SiteInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("bidders")]
        public List<string> Bidders { get; set; }
        [JsonProperty("floor")]
        public double Floor { get; set; }
        
        public SiteInfo() { }

        [JsonConstructor]
        public SiteInfo(string name, List<string> bidders, double floor)
        {
            Name = name;
            Bidders = bidders;
            Floor = floor;
        }
    }
}
