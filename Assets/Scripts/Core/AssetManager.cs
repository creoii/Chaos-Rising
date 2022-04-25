using UnityEngine;
using UnityEngine.U2D;
using UnityEditor.Sprites;

namespace ChaosRising
{
    public class AssetManager
    {
        public static readonly SpriteAtlas tiles = Resources.Load<SpriteAtlas>("Atlasses/Tiles");
        public static readonly SpriteAtlas items = Resources.Load<SpriteAtlas>("Atlasses/Items");
        public static readonly SpriteAtlas characters = Resources.Load<SpriteAtlas>("Atlasses/Characters");
        public static readonly SpriteAtlas projectiles = Resources.Load<SpriteAtlas>("Atlasses/Projectiles");
        public static readonly SpriteAtlas ui = Resources.Load<SpriteAtlas>("Atlasses/UI");

        public static Sprite GetTileSprite(string name)
        {
            return tiles.GetSprite(name);
        }

        public static Sprite GetItemSprite(string name)
        {
            return items.GetSprite(name);
        }

        public static Sprite GetCharacterSprite(string name)
        {
            return characters.GetSprite(name);
        }

        public static Sprite GetProjectileSprite(string name)
        {
            return projectiles.GetSprite(name);
        }

        public static Sprite GetUISprite(string name)
        {
            return ui.GetSprite(name);
        }
    }
}
