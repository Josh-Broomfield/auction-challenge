using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

namespace Auction_Challenge
{
    public class Config
    {
        public Dictionary<string, SiteInfo> Sites { get; set; }
        public Dictionary<string, BidderInfo> Bidders { get; set; }

        // Was going for efficiency here considering the scale of the auction app
        // you explained to me, but there's probably a better way to do it
        [JsonProperty("sites")]
        private List<SiteInfo> TmpSites { get; set; }
        [JsonProperty("bidders")]
        private List<BidderInfo> TmpBidders { get; set; }

        [JsonConstructor]
        public Config(List<SiteInfo> tmpSites, List<BidderInfo> tmpBidders)
        {
            Sites = tmpSites.ToDictionary(k => k.Name, v => v);
            Bidders = tmpBidders.ToDictionary(k => k.Name, v => v);
        }
    }
}