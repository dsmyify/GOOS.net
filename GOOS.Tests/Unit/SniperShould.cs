using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOOS.Core;
using NSubstitute;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace GOOS.Tests.Unit
{
    [TestFixture]
    public class SniperShould
    {
        [Test]
        public void NotBidAboveMaximumAmount()
        {
            var auction = Substitute.For<IAuction>();

            var sniper = new Sniper();
            sniper.Join(auction);
            sniper.Bid(120);

            auction.DidNotReceive().Bid(120, Arg.Any<string>());
        }
    }
}
