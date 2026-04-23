using UIPopupSystem.Core.Services;
using UIPopupSystem.Presenters;
using UIPopupSystem.Views;
using UnityEngine;

namespace UIPopupSystem.Core
{
    public class GameEntry : MonoBehaviour
    {
        [SerializeField] private PuzzleGridView gridView;
        [SerializeField] private StartPopupView startPopupView;

        private void Start()
        {
            IPuzzleLoader loader = new PuzzleLoader();
            IAdsService adsService = new AdsService();
            ICurrencyService currencyService = new CurrencyService();
            StartPopupPresenter popupPresenter = new StartPopupPresenter(startPopupView, currencyService, adsService);
            PopupManager popupManager = new PopupManager(popupPresenter);
            
            PuzzleGridPresenter presenter = new PuzzleGridPresenter(gridView, loader, popupManager);
            presenter.Init();
        }
    }
}