using System;
using GOOS.Core;

namespace GOOS.Tests
{
    public class FakeAuction : IAuction
    {
        private ISniper _sniper;

        public void StartSellingItem()
        {
            //todo connect to auction service and begin selling item
        }

        public void Join(ISniper sniper)
        {
            _sniper = sniper;
        }

        public void Close()
        {
            _sniper.Lost();
        }

        public void Bid(int price, string bidderId)
        {
            _sniper.Notified(price, 10, bidderId);
        }
    }
}