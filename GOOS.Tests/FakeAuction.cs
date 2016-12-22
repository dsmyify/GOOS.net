using System;
using GOOS.Core;

namespace GOOS.Tests
{
    internal class FakeAuction : IAuction
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
    }
}