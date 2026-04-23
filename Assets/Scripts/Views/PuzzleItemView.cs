using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIPopupSystem.Views
{
    public class PuzzleItemView : MonoBehaviour
    {
        [SerializeField] private Image preview;
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text modeText;

        private Action _clickAction;

        public void Init(Sprite sprite, string mode, Action onClick)
        {
            preview.sprite = sprite;
            modeText.text = mode;

            if (_clickAction != null)
                button.onClick.RemoveListener(OnClickInternal);

            _clickAction = onClick;
            button.onClick.AddListener(OnClickInternal);
        }

        private void OnClickInternal()
        {
            _clickAction?.Invoke();
        }
    }
}