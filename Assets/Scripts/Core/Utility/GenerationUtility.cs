using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ChaosRising
{
    public class GenerationUtility
    {
        private static TileBase[] tiles = Resources.LoadAll<TileBase>("Tiles");

        public static TileBase GetTile(string name)
        {
            foreach (TileBase tile in tiles)
            {
                if (tile.name == name) return tile;
            }
            return null;
        }

        public static TileBase[] GetTiles(string[] names)
        {
            List<TileBase> ret = new List<TileBase>();

            foreach (string name in names)
            {
                TileBase tile = GetTile(name);
                if (tile != null) ret.Add(tile);
            }
            return ret.ToArray();
        }

        public static bool isEdge(Vector3Int position, Vector4 size)
        {
            if (
                position.x == size.x ||
                position.x == size.x + (size.z - 1) ||
                position.y == size.y ||
                position.y == size.y + (size.w - 1)
                ) return true;
            else return false;
        }

        public static bool isEdgeBounds(Vector3Int position, Vector4 size, Vector4 bounds)
        {
            if (
                position.x == size.x + bounds.x ||
                position.x == (size.x + (size.z - 1)) - bounds.z ||
                position.y == size.y + bounds.y ||
                position.y == (size.y + (size.w - 1)) - bounds.w
                ) return true;
            else return false;
        }
    }
}
