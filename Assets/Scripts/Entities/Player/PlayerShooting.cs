using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public AudioSource audioSource;
    public static Weapon activeWeapon = Weapon.Sword;
    private Weapon lastActiveWeapon;
    private CameraController cameraController;
    private WeaponController weapon;
    void Start()
    {
        weapon = GetComponent<WeaponController>();
        cameraController = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
        switch(activeWeapon)
        {
            case Weapon.Sword:
                break;
        }
    }
    void Update()
    {
        if(lastActiveWeapon != activeWeapon)
        {
            switch(activeWeapon)
            {
                case Weapon.Sword:
                    break;
            }
            lastActiveWeapon = activeWeapon;
        }
        // if(UIManager.isPaused) return;
        if(Input.GetButton("Fire1") && weapon.canAttack)
            Attack();
    }
    void Attack()
    {
        string name = "Sword";
        switch(activeWeapon)
        {
            case Weapon.Sword:
            
        }
        audioSource.Play();
    }
}
