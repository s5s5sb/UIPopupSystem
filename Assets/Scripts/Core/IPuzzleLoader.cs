using System.Collections.Generic;
using UIPopupSystem.Data;

namespace UIPopupSystem.Core
{
    public interface IPuzzleLoader
    {
        public List<PuzzleData> Load();
    }
}