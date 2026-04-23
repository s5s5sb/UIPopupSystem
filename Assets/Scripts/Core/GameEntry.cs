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

        private PuzzleGridPresenter _presenter;

        private void Start()
        {
            IPuzzleLoader loader = new PuzzleLoader();
            IAdsService adsService = new AdsService();
            ICurrencyService currencyService = new CurrencyService();
            StartPopupPresenter popupPresenter = new StartPopupPresenter(startPopupView, currencyService, adsService);
            PopupManager popupManager = new PopupManager(popupPresenter);
            
            _presenter = new PuzzleGridPresenter(gridView, loader, popupManager, currencyService);
            _presenter.Init();
        }

        private void OnDestroy()
        {
            _presenter.Clear();
        }
    }
}