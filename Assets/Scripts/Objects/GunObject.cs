using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunObject : MonoBehaviour
{
    public Weapon localWeapon;
    // Start is called before the first frame update
     void OnTriggerEnter2D(Collider2D collider)
     {
        if(collider.CompareTag("Player"))
        {
            PlayerShooting.activeWeapon = localWeapon;
            Destroy(gameObject);
        }
     }
}
