using System.Collections.Generic;
using UIPopupSystem.Core;
using UIPopupSystem.Core.Services;
using UIPopupSystem.Data;
using UIPopupSystem.Views;

namespace UIPopupSystem.Presenters
{
    public class PuzzleGridPresenter
    {
        private readonly PuzzleGridView _view;
        private readonly IPuzzleLoader _loader;
        private readonly PopupManager _popupManager;
        private readonly ICurrencyService _currencyService;

        public PuzzleGridPresenter(PuzzleGridView view, IPuzzleLoader loader, PopupManager popupManager, 
            ICurrencyService currencyService)
        {
            _view = view;
            _loader = loader;
            _popupManager = popupManager;
            _currencyService = currencyService;
        }

        public void Init()
        {
            List<PuzzleData> puzzles = _loader.Load();
            _view.Clear();

            foreach (PuzzleData puzzle in puzzles)
            {
                PuzzleItemView item = _view.CreateItem();
                item.Init(puzzle.Preview, GetModeLabel(puzzle.Mode), () =>
                {
                    OnPuzzleSelected(puzzle);
                });
            }
            
            _view.SetCoinsText(_currencyService.Coins);
            _currencyService.OnCoinsChanged += OnCoinsChanged;
        }
        
        private void OnCoinsChanged(int coins)
        {
            _view.SetCoinsText(coins);
        }
        
        private void OnPuzzleSelected(PuzzleData puzzle)
        {
            _popupManager.ShowStartPopup(puzzle);
        }
        
        private string GetModeLabel(StartMode mode)
        {
            return mode.ToString();
        }

        public void Clear()
        {
            _currencyService.OnCoinsChanged -= OnCoinsChanged;
        }
    }
}