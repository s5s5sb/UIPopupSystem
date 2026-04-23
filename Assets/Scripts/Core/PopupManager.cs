using UIPopupSystem.Data;
using UIPopupSystem.Presenters;

namespace UIPopupSystem.Core
{
    public class PopupManager
    {
        private readonly StartPopupPresenter _startPopup;

        public PopupManager(StartPopupPresenter startPopup)
        {
            _startPopup = startPopup;
        }

        public void ShowStartPopup(PuzzleData data)
        {
            _startPopup.Show(data);
        }
    }
}