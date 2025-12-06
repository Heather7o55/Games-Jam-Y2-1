using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow2D : MonoBehaviour
{
    public Transform target;       // Player transform
    public float followSpeed = 10f; // Higher = snappier follow
    public float sprintZoom = 0.1f; // 10% zoom out when sprinting
    public float smoothZoomSpeed = 5f;

    private Camera cam;
    private float defaultSize;
    private bool isSprinting;

    void Start()
    {
        cam = GetComponent<Camera>();
        defaultSize = cam.orthographicSize;
    }

    void LateUpdate()
    {
        if (!target) return;

        // Smooth follow
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        // Smooth zoom
        float targetSize = isSprinting ? defaultSize * (1 + sprintZoom) : defaultSize;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, smoothZoomSpeed * Time.deltaTime);
    }

    // Call this from your player script
    public void SetSprint(bool sprinting)
    {
        isSprinting = sprinting;
    }
}
