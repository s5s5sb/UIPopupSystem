using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UIPopupSystem.Data;

namespace UIPopupSystem.Core
{
    public interface IPuzzleLoader
    {
        public UniTask<List<PuzzleData>> Load();
    }
}