using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GunController;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject rifleMuzzle;
    public GameObject pistolMuzzle;
    public GameObject shotgunMuzzle;
    public Animator guns;
    public int pellets = 5;
    public AudioClip pistol;
    public AudioClip rifle;
    public AudioClip sniper;
    public AudioClip shotgun;
    public AudioSource audioSource;
    public static Gun activeGun = Gun.Pistol;
    private Gun lastActiveGun;
    private CameraController cameraController;
    private GunController gun;
    void Start()
    {
        gun = GetComponent<GunController>();
        cameraController = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
        switch(activeGun)
        {
            case Gun.Pistol:
                Debug.Log("is pistol");
                guns.Play("PistolIdle");
                break;
            case Gun.Rifle:
                Debug.Log("is rifle");
                guns.Play("RifleIdle");
                break;
            case Gun.Shotgun:
                Debug.Log("is shotgun");
                guns.Play("ShotgunIdle");
                break;
            case Gun.Sniper:
                Debug.Log("is sniper");
                guns.Play("PistolIdle");
                break;
        }
    }
    void Update()
    {
        if(lastActiveGun != activeGun)
        {
            switch(activeGun)
            {
                case Gun.Pistol:
                    Debug.Log("is pistol");
                    guns.Play("PistolIdle");
                    break;
                case Gun.Rifle:
                    Debug.Log("is rifle");
                    guns.Play("RifleIdle");
                    break;
                case Gun.Shotgun:
                    Debug.Log("is shotgun");
                    guns.Play("ShotgunIdle");
                    break;
                case Gun.Sniper:
                    Debug.Log("is sniper");
                    guns.Play("PistolIdle");
                    break;
            }
            lastActiveGun = activeGun;
        }
        if(UIManager.isPaused) return;
        if(Input.GetButton("Fire1") && gun.canShoot)
            Shoot();
    }
    void Shoot()
    {
        string name = "Pistol";
        switch(activeGun)
        {
            case Gun.Pistol:
                cameraController.CameraShake(0.05f, 0.2f);
                
                gun.CreateBullet(0f, 30f, 1, pistolMuzzle.transform, transform, bulletPrefab);
                audioSource.clip = pistol;
                gun.StartGunCooldown(0.3f);
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                name = "Pistol";
                pistolMuzzle.GetComponent<Animator>().Play("MuzzleFlash");
                break;
            case Gun.Rifle:
                cameraController.CameraShake(0.05f, 0.2f);
                gun.CreateBullet(0f, 30f, 1, rifleMuzzle.transform, transform, bulletPrefab);
                audioSource.clip = rifle;
                gun.StartGunCooldown(0.12f);
                name = "Rifle";
                rifleMuzzle.GetComponent<Animator>().Play("MuzzleFlash");
                break;
            case Gun.Shotgun:
                cameraController.CameraShake(0.2f, 0.3f);
                gun.Shotgun(shotgunMuzzle.transform, transform, bulletPrefab, pellets);
                audioSource.clip = shotgun;
                gun.StartGunCooldown(0.8f);
                audioSource.pitch = Random.Range(0.8f, 1.2f);
                name = "Shotgun";
                shotgunMuzzle.GetComponent<Animator>().Play("MuzzleFlash");
                break;
            case Gun.Sniper:
                cameraController.CameraShake(0.2f, 0.3f);
                gun.CreateBullet(0f, 50f, 3, pistolMuzzle.transform, transform, bulletPrefab);
                audioSource.clip = sniper;
                gun.StartGunCooldown(0.75f);
                audioSource.pitch = 1;
                name = "Pistol";
                pistolMuzzle.GetComponent<Animator>().Play("MuzzleFlash");
                break;
        }
        audioSource.Play();
        guns.Play(name);
    }
   
    
}
