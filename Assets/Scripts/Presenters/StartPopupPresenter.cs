using UIPopupSystem.Core.Services;
using UIPopupSystem.Data;
using UIPopupSystem.Views;
using UnityEngine;

namespace UIPopupSystem.Presenters
{
    public class StartPopupPresenter
    {
        private readonly StartPopupView _view;
        private readonly ICurrencyService _currencyService;
        private readonly IAdsService _adsService;
        private PuzzleData _currentPuzzle;

        public StartPopupPresenter(StartPopupView view, ICurrencyService currencyService, IAdsService adsService)
        {
            _view = view;
            _currencyService = currencyService;
            _adsService = adsService;
        }

        public void Show(PuzzleData puzzle)
        {
            _currentPuzzle = puzzle;

            int coins = _currencyService.Coins;
            _view.SetCoinsText(coins);
            _view.SetPreview(puzzle.Preview);
            _view.SetPlayText($"Play {puzzle.Mode}");
            _view.SetListeners(OnPlay, OnClose);
            _view.Show();
        }

        private void OnPlay()
        {
            switch (_currentPuzzle.Mode)
            {
                case StartMode.Free:
                    Debug.Log("Start FREE");
                    StartGame();
                    break;

                case StartMode.Coins:
                    Debug.Log("Start with COINS");
                    if (_currencyService.TrySpend(100))
                    {
                        _view.SetCoinsText(_currencyService.Coins);
                        StartGame();
                    }
                    break;

                case StartMode.Ads:
                    Debug.Log("Start with ADS");
                    _adsService.ShowRewardedAd(StartGame);
                    break;
            }
        }

        private void StartGame()
        {
            Debug.Log("Game Started");
        }

        private void OnClose()
        {
            _view.Hide();
        }
    }
}