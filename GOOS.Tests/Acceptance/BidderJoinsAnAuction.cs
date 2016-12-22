using GOOS.Core;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using StoryQ;

namespace GOOS.Tests.Acceptance
{
    [TestFixture]
    public class BidderJoinsAnAuction
    {
        readonly Feature _feature = 
            new Story("Bidder joins an auction")
                .InOrderTo("Increase chance of winning an item in an auction")
                .AsA("Bidder")
                .IWant("Increase chance of winning an item in an auction that has started.");

        readonly IAuction _auction = Substitute.For<FakeAuction>();
        readonly ISniper _sniper = Substitute.For<Sniper>();

        [Test]
        public void Feature_AuctionClosesBidderLoses()
        {
            _feature.WithScenario("Auction closes and bidder loses")
                .Given(AuctionHasBegun)
                .And(SniperJoinedAuction)
                .When(AuctionHasClosed)
                .Then(SniperHasLostAuction)

                .ExecuteWithReport();
        }

        [Test]
        public void Feature_BidMadeAuctionClosesBidderLoses()
        {
            _feature.WithScenario("Bid was made but auction closes and the bidder loses")
                .Given(AuctionHasBegun)
                .And(SniperJoinedAuction)
                .And(AuctionReportsBid, 100, 10, "other bidder")
                .And(AuctionRecievesBid, 110, "sniper-id")
                .When(AuctionHasClosed)
                .Then(SniperHasLostAuction)

                .ExecuteWithReport();
        }




        private void AuctionHasBegun()
        {
            _auction.StartSellingItem();
        }

        private void SniperJoinedAuction()
        {
            _sniper.Join(_auction);
        }

        private void AuctionReportsBid(int price, int minBid, string bidderId)
        {
            _auction.Bid(price, bidderId);

            // check that sniper is notified of the new price, minimum bid amount and the winning bidderId
            _sniper.Received().Notified(price, minBid, bidderId);
        }

        private void AuctionRecievesBid(int bid, string bidderId)
        {
            // check that the sniper automatically bid
             _sniper.Received().Bid(110);

            // check that auction recieved snipers new bid
            _auction.Received().Bid(110, "sniper-id");
        }

        private void AuctionHasClosed()
        {
            _auction.Close();
        }

        private void SniperHasLostAuction()
        {
            _sniper.Received().Lost();
        }
    }
}
