using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_Challenge
{
    public class Auction
    {
        [JsonProperty("site")]
        public string Site { get; set; }
        [JsonProperty("units")]
        public List<string> Units { get; set; }
        [JsonProperty("bids")]
        public List<Bid> Bids { get; set; }

        public Auction(string site, List<string> units, List<Bid> bids)
        {
            Site = site;
            Units = units;
            Bids = bids;
        }
    }
}
