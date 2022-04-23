using UnityEngine;

namespace ChaosRising
{
    public class AssetManager
    {
        public static readonly Sprite[] items = Resources.LoadAll<Sprite>("Spritesheets/items");
        public static readonly Sprite[] projectiles = Resources.LoadAll<Sprite>("Spritesheets/projectiles");
        public static readonly Sprite[] classes = Resources.LoadAll<Sprite>("Spritesheets/classes");
        public static readonly Sprite[] enemies = Resources.LoadAll<Sprite>("Spritesheets/enemies");
        public static readonly Sprite[] ui = Resources.LoadAll<Sprite>("Spritesheets/ui");

        public static Sprite GetItemSprite(string name)
        {
            foreach (Sprite sprite in items)
            {
                if (sprite.name == name) return sprite;
            }
            return null;
        }

        public static Sprite GetProjectileSprite(string name)
        {
            foreach (Sprite sprite in projectiles)
            {
                if (sprite.name == name) return sprite;
            }
            return null;
        }

        public static Sprite GetClassSprite(string name)
        {
            foreach (Sprite sprite in classes)
            {
                if (sprite.name == name) return sprite;
            }
            return null;
        }

        public static Sprite GetEnemySprite(string name)
        {
            foreach (Sprite sprite in enemies)
            {
                if (sprite.name == name) return sprite;
            }
            return null;
        }

        public static Sprite GetUISprite(string name)
        {
            foreach (Sprite sprite in ui)
            {
                if (sprite.name == name) return sprite;
            }
            return null;
        }
    }
}
