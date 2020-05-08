using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Auction_Challenge
{
    public class AuctionChallenge
    {
        public Config MyConfig { get; set; }
        public List<Auction> Auctions { get; set; }
        public List<List<Bid>> AuctionResults { get; set; }

        public AuctionChallenge()
        {
            AuctionResults = new List<List<Bid>>();
        }

        /// <summary>
        /// Resolves auctions for each site's units and stores the results in AuctionResults
        /// </summary>
        public void RunAuctions()
        {
            AuctionResults.Clear();

            List<string> validSites = new List<string>(MyConfig.Sites.Keys);

            Auctions = Auctions.Select(auction =>//removes bids from invalid sites, that way the results will be empty
            {
                if (!validSites.Contains(auction.Site))
                {
                    auction.Bids.Clear();
                }

                return auction;
            }).ToList();//would have but this below, but it makes it look terrible

            AuctionResults = Auctions.Select(auction => //foreach auction
                auction.Units.Select(unit =>//foreach unit
                    auction.Bids.Where(bid => bid.Unit == unit &&                                               //valid units
                                                MyConfig.Sites[auction.Site].Bidders.Contains(bid.Bidder) &&    //valid bidders
                                                GetAdjustedBid(bid) >= MyConfig.Sites[auction.Site].Floor)      //valid minimum bid. Invalid sites had their bids culled, so no need to worry about indexing exceptions
                                .OrderByDescending(bid => GetAdjustedBid(bid))
                                .Select(bid => bid)//new AuctionUnitResult(bid.Bidder, bid.BidAmt, bid.Unit))
                                .FirstOrDefault()//Winning bid in a unit.
                                //From what I understand, linq does not waste time converting the other items in the above .Select, only the first.
                ).Where(unitRes => unitRes != null).ToList()//winning bid for each unit. Ignores ones that did not have a winner, aka null results
            ).ToList();//will keep empty auctions
        }

        private double GetAdjustedBid(Bid bid) => bid.BidAmt + (bid.BidAmt * MyConfig.Bidders[bid.Bidder].Adjustment);

        /// <summary>
        /// Loads the configs from json string
        /// </summary>
        /// <param name="configString">File contents from json config file</param>
        public void LoadConfig(string configString)
        {
            MyConfig = JsonConvert.DeserializeObject<Config>(configString);
        }

        /// <summary>
        /// Loads input from json string
        /// </summary>
        /// <param name="inputString">File contents from json input file</param>
        public void LoadInput(string inputString)
        {
            Auctions = JsonConvert.DeserializeObject<List<Auction>>(inputString);
        }
    }
}
