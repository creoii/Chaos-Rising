using System;
using UnityEngine;

namespace ChaosRising
{
    [Serializable]
    public class Dungeon
    {
        public Vector2Int position;

        public Room[] rooms;
    }
}
