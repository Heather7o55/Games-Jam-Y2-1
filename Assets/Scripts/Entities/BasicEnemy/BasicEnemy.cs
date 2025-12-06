using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : BaseEntity
{
    public int speed;
    private bool stunned = false;
    public float timer;
    public override void OnTakeDamage()
    {
        
    }
    private GameObject playerObj;
    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        Vector3 direction = playerObj.transform.position - transform.position;
        if(stunned) return;
        transform.position = Vector2.MoveTowards(transform.position, playerObj.transform.position, speed * Time.deltaTime);
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        selfRigidBody.rotation = angle;
    }
    public void Stun()
    {
        StartCoroutine(CoolDown(timer));
    }
    private IEnumerator CoolDown(float timer)
    {
        stunned = true;
        yield return new WaitForSeconds(timer);
        stunned = false;
    }
}
