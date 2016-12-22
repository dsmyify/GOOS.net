namespace GOOS.Core
{
    public interface IAuction
    {
        void StartSellingItem();
        void Join(ISniper sniper);
        void Bid(int price, string bidderId);
        void Close();
    }
}