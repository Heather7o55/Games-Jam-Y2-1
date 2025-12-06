using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : BaseEntity
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    Renderer self;
    Vector3 tmp;
    NavMeshAgent agent;
    GameObject player;
    private GunController gun;
    bool canSeePlayer = false;
    bool canShootPlayer = false;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        gun = GetComponent<GunController>();
        audioSource = GetComponent<AudioSource>();
        Setup();
        tmp = transform.position;
        self = GetComponent<Renderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindWithTag("Player");
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player")) col.gameObject.GetComponent<BaseEntity>()?.ModifyHealth(-1);
    }

    // Update is called once per frame
    void Update()
    { 
        if(!self.isVisible) return;
        
        if(canSeePlayer)
        {
            tmp = player.transform.position;
            Vector3 direction = tmp - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            selfRigidBody.rotation = angle;
        } 
        if(canShootPlayer && gun.canShoot) Shoot();
        agent.SetDestination(tmp);
    }
    void Shoot()
    {
        Debug.Log("enemy shooting");
        //anim.Play("MuzzleFlash");
        gun.CreateBullet(0f, 25f, 1, bulletSpawnPoint, transform, bulletPrefab);
        gun.StartGunCooldown(0.5f);
        audioSource.Play();
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) 
        {
            canSeePlayer = true;
            canShootPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canShootPlayer = false;
            StartCoroutine(LoosesInterest(2f));
        } 
    }
    IEnumerator LoosesInterest(float timer)
    {
        canSeePlayer = true;
        yield return new WaitForSeconds(timer);
        canSeePlayer = false;
    }
    public override void OnTakeDamage()
    {
        tmp = player.transform.position;
    }
}
