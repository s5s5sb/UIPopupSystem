using System.Collections.Generic;
using System.Threading.Tasks;
using UIPopupSystem.Data;

namespace UIPopupSystem.Core
{
    public interface IPuzzleLoader
    {
        public Task<List<PuzzleData>> Load();
    }
}