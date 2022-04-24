using System;
using UnityEngine;

namespace ChaosRising
{
    [Serializable]
    public class Dungeon
    {
        public string name;
        public Vector2Int position;

        public Room[] rooms;
    }
}
