using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : BaseEntity
{
    public int speed;
    public Animator anim;
    private bool stunned = false;
    public float timer;
    public override void OnTakeDamage()
    {
        
    }
    private GameObject playerObj;
    void Start()
    {
        anim = GetComponent<Animator>();
        playerObj = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        Vector3 direction = playerObj.transform.position - transform.position;
        if(stunned) return;
        anim.Play("EnemyWalking");
        transform.position = Vector2.MoveTowards(transform.position, playerObj.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, direction)));
    
    }
    public void Stun()
    {
        anim.Play("BlockEnemy");
        StartCoroutine(CoolDown(timer));
    }
    private IEnumerator CoolDown(float timer)
    {
        stunned = true;
        yield return new WaitForSeconds(timer);
        stunned = false;
    }
}
