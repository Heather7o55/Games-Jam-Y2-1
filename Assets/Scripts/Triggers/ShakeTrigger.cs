using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTrigger : MonoBehaviour
{
    private GameObject cameraRef;
    private CameraController cameraScript;
    // Start is called before the first frame update
    void Start()
    {
        cameraRef = GameObject.FindWithTag("MainCamera");
        cameraScript = cameraRef.GetComponent<CameraController>();
    }

    // Update is called once per frame
   private void OnCollisionEnter2D(Collision2D col)
   {
        if(col.gameObject.CompareTag("Player"))
        {
            cameraScript.CameraShake(0.2f, 0.1f);
        }
   }
}
