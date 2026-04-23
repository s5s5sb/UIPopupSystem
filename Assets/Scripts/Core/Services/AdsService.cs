using System;

namespace UIPopupSystem.Core.Services
{
    public class AdsService : IAdsService
    {
        public void ShowRewardedAd(Action onCompleted)
        {
            onCompleted?.Invoke();
        }
    }
}
