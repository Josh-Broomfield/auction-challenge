using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_Challenge
{
    public class Bid
    {
        [JsonProperty("bidder")]
        public string Bidder { get; set; }
        [JsonProperty("bid")]
        public double BidAmt { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
        
        public Bid(string bidder, string unit, double bidAmt)
        {
            Bidder = bidder;
            Unit = unit;
            BidAmt = bidAmt;
        }
    }
}
