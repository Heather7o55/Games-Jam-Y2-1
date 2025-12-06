using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorsoRotation : MonoBehaviour
{
    //GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        //hand = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(true) UpdatePlayerRotation();
    }
    private void UpdatePlayerRotation()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));
        //hand.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, mousePosition - hand.transform.position)));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, mousePosition - transform.position)));
    }
}
