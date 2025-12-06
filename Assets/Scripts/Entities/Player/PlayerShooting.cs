using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject AttackBox;
    public static Weapon activeWeapon = Weapon.Sword;
    public Animator anim;
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
            // switch(activeWeapon)
            // {
            //     case Weapon.Sword:
            //         break;
            // }
            lastActiveWeapon = activeWeapon;
        }
        // if(UIManager.isPaused) return;
        Attack();
        AttackBox.SetActive(weapon.canAttack);
        if(weapon.canAttack)
        {
            anim.Play("WalkingPlayer");
        }
        else
        {
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                {
                    anim.Play("AttackPlayer");
                }
        }
    }
    void Attack()
    {
        if(Input.GetButton("Fire1"))
        {
            weapon.StartCooldown(0.2f);
        }
        
        string name = "Sword";
        // switch(activeWeapon)
        // {
        //     case Weapon.Sword:
            
        // }
    }
}
