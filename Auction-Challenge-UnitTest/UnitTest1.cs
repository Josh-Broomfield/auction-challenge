using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Auction_Challenge;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Auction_Challenge_UnitTest
{
    /// <summary>
    /// All these tests use the default config.json located in root/auction
    /// The inputs are generated in each test
    /// </summary>
    [TestFixture()]
    public class UnitTest1
    {
        public AuctionChallenge Ac { get; set; }

        [SetUp]
        public void SetUp()
        {
            Ac = new AuctionChallenge();

            SiteInfo site = new SiteInfo("houseofcheese.com", new List<string>() { "AUCT", "BIDD" }, 32);
            List<BidderInfo> bidders = new List<BidderInfo>()
            {
                new BidderInfo("AUCT", -0.065),
                new BidderInfo("BIDD", 0)
            };

            Config config = new Config(new List<SiteInfo>() { site }, bidders);

            Ac.MyConfig = config;
        }

        [Test()]
        public void Auction_InvalidSite_Empty()
        {
            List<Bid> bids = new List<Bid>()
            {
                new Bid("AUCT", "banner", 35),
                new Bid("BIDD", "sidebar", 60)
            };
            Auction auction = new Auction("nothouseofcheese.com", new List<string>() { "banner", "sidebar" }, bids);

            Ac.Auctions = new List<Auction>() { auction };
            Ac.RunAuctions();

            Assert.AreEqual(0, Ac.AuctionResults[0].Count());
        }

        [Test()]
        public void Auction_AllBidsTooLow_NoWinner()
        {
            List<Bid> bids = new List<Bid>()
            {
                new Bid("AUCT", "banner", 31),
                new Bid("BIDD", "sidebar", 31)
            };
            Auction auction = new Auction("houseofcheese.com", new List<string>() { "banner", "sidebar" }, bids);

            Ac.Auctions = new List<Auction>() { auction };
            Ac.RunAuctions();

            Assert.AreEqual(0, Ac.AuctionResults[0].Count());
        }

        [Test()]
        public void Auction_InvalidBidder_DoesntWin()
        {
            List<Bid> bids = new List<Bid>()
            {
                new Bid("NOTAUCT", "banner", 500),
                new Bid("BIDD", "banner", 60)
            };
            Auction auction = new Auction("houseofcheese.com", new List<string>() { "banner", "sidebar" }, bids);

            Ac.Auctions = new List<Auction>() { auction };
            Ac.RunAuctions();


            Assert.AreEqual("BIDD", Ac.AuctionResults[0][0].Bidder);
        }

        [Test()]
        public void Auction_InvalidUnit_NoWinner()
        {
            List<Bid> bids = new List<Bid>()
            {
                new Bid("AUCT", "footer", 50),
                new Bid("BIDD", "footer", 55),
                new Bid("AUCT", "footer", 63)
            };
            Auction auction = new Auction("houseofcheese.com", new List<string>() { "banner", "sidebar" }, bids);

            Ac.Auctions = new List<Auction>() { auction };
            Ac.RunAuctions();


            Assert.AreEqual(0, Ac.AuctionResults[0].Count());
        }

        [Test()]
        public void Auction_HighBidWins_AUCTWins()
        {
            List<Bid> bids = new List<Bid>()
            {
                new Bid("AUCT", "banner", 96),
                new Bid("BIDD", "banner", 85),
                new Bid("BIDD", "banner", 75),
                new Bid("BIDD", "banner", 65)
            };
            Auction auction = new Auction("houseofcheese.com", new List<string>() { "banner", "sidebar" }, bids);

            Ac.Auctions = new List<Auction>() { auction };
            Ac.RunAuctions();

            Assert.AreEqual("AUCT", Ac.AuctionResults[0][0].Bidder);
        }
    }
}
