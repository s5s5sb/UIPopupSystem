using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UIPopupSystem.Data;

namespace UIPopupSystem.Core
{
    public class PuzzleLoader : IPuzzleLoader
    {
        public List<PuzzleData> Load()
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>("Puzzles");

            return sprites.Select((sprite, index) => new PuzzleData
                {
                    Preview = sprite,
                    Mode = index switch
                    {
                        < 2 => StartMode.Free,
                        < 5 => StartMode.Coins,
                        _ => StartMode.Ads
                    }}).ToList();
        }
    }
}