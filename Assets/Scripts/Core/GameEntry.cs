using System;
using Cysharp.Threading.Tasks;
using UIPopupSystem.Core.Services;
using UIPopupSystem.Presenters;
using UIPopupSystem.Views;
using UnityEngine;
using VContainer;

namespace UIPopupSystem.Core
{
    public class GameEntry : MonoBehaviour
    {
        [SerializeField] private PuzzleGridView gridView;
        [SerializeField] private StartPopupView startPopupView;

        private PuzzleGridPresenter _presenter;
        private IPuzzleLoader _loader;
        private IAdsService _adsService;
        private ICurrencyService _currencyService;

        [Inject]
        private void Construct(IPuzzleLoader loader, IAdsService adsService, ICurrencyService currencyService)
        {
            _loader = loader;
            _adsService = adsService;
            _currencyService = currencyService;
        }
        
        private void Start()
        {
            Initialize().Forget();
        }

        private async UniTask Initialize()
        {
            try
            {
                StartPopupPresenter popupPresenter = new StartPopupPresenter(startPopupView, _currencyService, _adsService);
                PopupManager popupManager = new PopupManager(popupPresenter);
                
                _presenter = new PuzzleGridPresenter(gridView, _loader, popupManager, _currencyService);
                await _presenter.Init();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private void OnDestroy()
        {
            _presenter.Clear();
        }
    }
}