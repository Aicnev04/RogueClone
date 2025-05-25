using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                      // Player
    public Vector3 offset = new Vector3(0, 10, -10); // Offset from player
    public float followSpeed = 5f;
    public Vector2 followThreshold = new Vector2(3f, 2f); // X and Z thresholds

    public Vector3 initialRotation;

    void Start()
    {
        // Save initial rotation so we don't rotate later
        initialRotation = transform.eulerAngles;
    }

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desiredPosition = target.position + offset;

        // Only move camera if player exceeds thresholds
        Vector3 cameraFlat = transform.position;
        cameraFlat.y = 0;
        Vector3 targetFlat = desiredPosition;
        targetFlat.y = 0;
        Vector3 diff = targetFlat - cameraFlat;

        bool moveX = Mathf.Abs(diff.x) > followThreshold.x;
        bool moveZ = Mathf.Abs(diff.z) > followThreshold.y;

        if (moveX || moveZ)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.position = newPosition;
        }

        // Lock camera rotation
        transform.eulerAngles = initialRotation;
    }
}