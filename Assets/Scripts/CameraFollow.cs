using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float smoothSpeed = 0.125f;

    public Vector2 minPosition; // Límite inferior izquierdo
    public Vector2 maxPosition; // Límite superior derecho

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // Clamping en X e Y
        float clampedX = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, desiredPosition.z), smoothSpeed);
        transform.position = smoothedPosition;
    }
}
