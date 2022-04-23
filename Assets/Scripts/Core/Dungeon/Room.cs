using System;
using UnityEngine;

namespace ChaosRising
{
    [Serializable]
    public class Room
    {
        public Vector2Int position;

        public string[] groundTiles;
        public string[] wallTiles;

        public int minWidth;
        public int maxWidth;
        public int minHeight;
        public int maxHeight;
        
        public int boundOffsetX;
        public int boundOffsetY;
        public Vector4 bounds;

        public Room(int minWidth, int maxWidth, int minHeight, int maxHeight, int boundOffsetX, int boundOffsetY)
        {
            this.minWidth = minWidth;
            this.maxWidth = maxWidth;
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
            this.boundOffsetX = boundOffsetX;
            this.boundOffsetY = boundOffsetY;
        }
    }
}
