using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Vector3 basePos;
    public GameObject parent;
    private GameObject player;
    Vector3 followTarget;
    void Start()
    {
        player = GameObject.FindWithTag("mouselook");
        if(player != null)followTarget = player.transform.localPosition;
        basePos = transform.position;
    }
    public float smoothTime = 0.3f;
    public void CameraShake(float duration, float magnitude)
    {
        // This is in its own function as for some reason unity doesn't allow me to call an Enumerator from another class even if its public??? 
        StartCoroutine(Shake(duration, magnitude));
    }
    private IEnumerator Shake(float duration, float magnitude)
    {
        float elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            transform.position = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = Vector3.zero;
    }
    public void ZoomCamera(float target, float zoomSpeed)
    {
        GetComponent<Camera>().fieldOfView = Mathf.MoveTowards(GetComponent<Camera>().fieldOfView, target, zoomSpeed * Time.deltaTime);
    }
    void LateUpdate()
    {
        if(player != null)updatecamera();
    }
    
    private void UpdateCameraPosition(Vector3 Position, float smoothing)
    {
        parent.transform.position = Vector3.SmoothDamp(parent.transform.position, Position, ref velocity, smoothing);
    }
    private void updatecamera()
    {
        followTarget = player.transform.position;
        followTarget.z = parent.transform.position.z;
        smoothTime = 0.3f; 
        UpdateCameraPosition(followTarget, smoothTime);
    }   
}
