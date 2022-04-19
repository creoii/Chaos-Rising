using UnityEngine;

namespace ChaosRising
{
    public class MouseUtility
    {
        private static Vector3 mousePosition;
        private static Vector3 mouseDirection;

        public static Vector3 GetMousePosition()
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            return mousePosition;
        }

        public static Vector3 GetMouseDirection(Vector3 from, bool normalize)
        {
            mouseDirection = GetMousePosition() - from;
            return normalize ? mouseDirection.normalized : mouseDirection;
        }

        public static float GetMouseAngle(Vector3 from, bool normalize)
        {
            Vector3 direction = GetMouseDirection(from, normalize);
            return Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        }
    }
}
