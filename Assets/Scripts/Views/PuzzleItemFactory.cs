using UnityEngine;

namespace UIPopupSystem.Views
{
    public class PuzzleItemFactory : IPuzzleItemFactory
    {
        private readonly PuzzleItemView _prefab;
        private readonly Transform _container;
        
        private int _counter;

        public PuzzleItemFactory(PuzzleItemView prefab, Transform container)
        {
            _prefab = prefab;
            _container = container;
        }
        
        public PuzzleItemView Create()
        {
            PuzzleItemView item = Object.Instantiate(_prefab, _container);
            item.name = $"PuzzleItem_{_counter++}";
            return item;
        }
    }
}