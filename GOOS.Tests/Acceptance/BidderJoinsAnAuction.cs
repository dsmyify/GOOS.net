using GOOS.Core;
using NSubstitute;
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

        readonly FakeAuction _auction = new FakeAuction();
        readonly ISniper _sniper = Substitute.For<ISniper>();

        [Test]
        public void AuctionClosesBidderLoses()
        {
            _feature.WithScenario("Auction closes and bidder Loses")
                .Given(AuctionHasBegun)
                .And(SniperJoinedAuction)
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
            _auction.Join(_sniper);
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
