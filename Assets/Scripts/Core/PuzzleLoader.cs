using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UIPopupSystem.Data;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;

namespace UIPopupSystem.Core
{
    public class PuzzleLoader : IPuzzleLoader
    {
        private const string AtlasKey = "Puzzles";

        public async UniTask<List<PuzzleData>> Load()
        {
            SpriteAtlas atlas = await Addressables.LoadAssetAsync<SpriteAtlas>(AtlasKey).ToUniTask();
            Sprite[] sprites = new Sprite[atlas.spriteCount];
            atlas.GetSprites(sprites);

            return sprites
                .OrderBy(x => x.name)
                .Select((sprite, index) => new PuzzleData
                {
                    Preview = sprite,
                    Mode = index switch
                    {
                        < 2 => StartMode.Free,
                        < 5 => StartMode.Coins,
                        _ => StartMode.Ads
                    }
                })
                .ToList();
        }
    }
}