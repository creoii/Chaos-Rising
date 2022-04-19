using UnityEngine;

namespace ChaosRising
{
    public class MathUtility
    {
        public const float Deg2Rad = .01745329f;
        public const float Rad2Deg = 57.29578f;

        public static Vector3 GetDirection(Vector3 from, float angle)
        {
            return new Vector3(from.x + Mathf.Cos(angle * Deg2Rad), from.y + Mathf.Sin(angle * Deg2Rad)).normalized;
        }
    }
}
