using System;

namespace UIPopupSystem.Core.Services
{
    public interface IAdsService
    {
        public void ShowRewardedAd(Action onCompleted);
    }
}