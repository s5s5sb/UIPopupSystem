using TMPro;
using UnityEngine;

namespace UIPopupSystem.Views
{
    public class PuzzleGridView : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private PuzzleItemView itemPrefab;
        [SerializeField] private TMP_Text coinsText;
        
        private IPuzzleItemFactory _puzzleFactory;

        private void Awake()
        {
            _puzzleFactory = new PuzzleItemFactory(itemPrefab,  container);
        }

        public PuzzleItemView CreateItem()
        {
            return _puzzleFactory.Create();
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