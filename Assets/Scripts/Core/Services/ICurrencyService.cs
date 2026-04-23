using System;

namespace UIPopupSystem.Core.Services
{
    public interface ICurrencyService
    {
        public int Coins { get; }
        public bool TrySpend(int amount);
        public event Action<int> OnCoinsChanged;
    }
}