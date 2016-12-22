namespace GOOS.Core
{
    public interface ISniper
    {
        void Join(IAuction auction);
        void Notified(int price, int minBid, string bidderId);
        void Bid(int offer);
        void Lost();
    }
}