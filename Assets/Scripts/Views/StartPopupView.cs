using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIPopupSystem.Views
{
    public class StartPopupView : MonoBehaviour
    {
        [SerializeField] private Image preview;
        [SerializeField] private Button playButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private TMP_Text playText;
        [SerializeField] private TMP_Text coinsText;

        public void SetCoinsText(int value)
        {
            coinsText.text = $"COINS: {value}";
        }
        
        public void SetPlayText(string text)
        {
            playText.text = text;
        }

        public void SetPreview(Sprite sprite)
        {
            preview.sprite = sprite;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetListeners(Action onPlay, Action onClose)
        {
            playButton.onClick.RemoveAllListeners();
            closeButton.onClick.RemoveAllListeners();
            
            playButton.onClick.AddListener(() => onPlay());
            closeButton.onClick.AddListener(() => onClose());
        }
    }
}