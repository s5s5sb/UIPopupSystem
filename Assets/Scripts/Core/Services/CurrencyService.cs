namespace UIPopupSystem.Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        private int _coins = 1000;
        
        public int Coins => _coins;

        public bool TrySpend(int cost)
        {
            if (_coins < cost)
            {
                return false;
            }

            _coins -= cost;
            return true;
        }
    }
}
