using UnityEngine;

namespace UIPopupSystem.Views
{
    public class PuzzleGridView : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private PuzzleItemView itemPrefab;

        public PuzzleItemView CreateItem()
        {
            return Instantiate(itemPrefab, container);
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