namespace UIPopupSystem.Core.Services
{
    public interface ICurrencyService
    {
        public int Coins { get; }
        public bool TrySpend(int cost);
    }
}
