using System;

namespace GOOS.Core
{
    public class Sniper : ISniper
    {
        public const string Id = "sniper-id";
        private IAuction _auction;

        public void Join(IAuction auction)
        {
            this._auction = auction;
            auction.Join(this);
        }

        public void Notified(int price, int minBid, string bidderId)
        {
            this.Bid(price + minBid);
        }

        public void Bid(int offer)
        {
            var maxOffer = 110;
            if (offer <= maxOffer)
                _auction.Bid(offer, Id);
        }

        public void Lost()
        {

        }
    }
}