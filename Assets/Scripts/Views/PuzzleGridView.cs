using TMPro;
using UnityEngine;

namespace UIPopupSystem.Views
{
    public class PuzzleGridView : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private PuzzleItemView itemPrefab;
        [SerializeField] private TMP_Text coinsText;

        public PuzzleItemView CreateItem()
        {
            return Instantiate(itemPrefab, container);
        }
        
        public void SetCoinsText(int value)
        {
            coinsText.text = $"COINS: {value}";
        }

        public void Clear()
        {
            foreach (Transform child in container)
            {
                Destroy(child.gameObject);
            }
        }
    }
}