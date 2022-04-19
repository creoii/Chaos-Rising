using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float zOffset;

    public float seekSpeed;
    private Vector3 seek;

    private void LateUpdate()
    {
        seek = Input.mousePosition;
        seek.x -= Screen.width / 2f;
        seek.y -= Screen.height / 2f;
        seek.x /= Screen.width;
        seek.y /= Screen.width;
        seek.z = zOffset;
        transform.position = Vector3.Lerp(transform.position, target.position + seek, seekSpeed);
    }
}
