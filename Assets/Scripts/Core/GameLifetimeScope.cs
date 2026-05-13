using UIPopupSystem.Core.Services;
using VContainer;
using VContainer.Unity;

namespace UIPopupSystem.Core
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IPuzzleLoader, PuzzleLoader>(Lifetime.Singleton);
            builder.Register<IAdsService, AdsService>(Lifetime.Singleton);
            builder.Register<ICurrencyService, CurrencyService>(Lifetime.Singleton);
            
            builder.RegisterComponentInHierarchy<GameEntry>();
        }
    }
}