using UnityEngine;

namespace UIPopupSystem.Data
{
    public enum StartMode
    {
        Free,
        Coins,
        Ads
    }
    
    public class PuzzleData
    {
        public Sprite Preview;
        public StartMode Mode;
    }
}