using System;

namespace UIPopupSystem.Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        public event Action<int> OnCoinsChanged;
        public int Coins { get; private set; } = 1000;

        public bool TrySpend(int amount)
        {
            if (Coins < amount)
            {
                return false;
            }

            OnCoinsChanged?.Invoke(Coins);
            Coins -= amount;
            return true;
        }
    }
}