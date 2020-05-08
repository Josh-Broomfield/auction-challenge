using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_Challenge
{
    public class BidderInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("adjustment")]
        public double Adjustment { get; set; }

        public BidderInfo(string name, double adjustment)
        {
            Name = name;
            Adjustment = adjustment;
        }
    }
}
