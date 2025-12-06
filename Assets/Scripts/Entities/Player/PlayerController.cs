using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;      
public class PlayerController : BaseEntity
{
    float slideCoolDown = 0.4f;
    bool isSlideCooldown = false;
    private float slideSpeed = 500f;
    private bool isSliding = false;
    private float moveSpeed = 10f;
    private float sprintModifier = 1.5f;
    private CameraController cameraScript;
    private Vector2 moveDirection;
    private GameObject HUD;
    public Animator anim;
    public SpriteRenderer[] playerSprites;
    void Start()
    {
        maxHealth = 10;
        Setup();
        cameraScript = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
        HUD = GameObject.FindWithTag("HUD");
    }
    void Update()
    {
        // Debug.Log(gameObject.name + "'s velocity is " + selfRigidBody.velocity);
        // Debug.Log("The current <b>timestamp</b> is " + Time.time);
        if(UIManager.isPaused) return;
        UpdateMovement();
        UpdateHUD();
        UpdateCamera();
    }
    private void UpdateHUD()
    {
        HUD.GetComponentInChildren<Animator>().SetFloat("Speed", currentHealth / 10f);
    }
    private void UpdateMovement()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDirection.Normalize();
        if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.Space)) && !isSliding && !isSlideCooldown)
            Slide();
        else if(Input.GetKey(KeyCode.LeftShift) && !isSliding)
            selfRigidBody.linearVelocity = moveDirection * moveSpeed * sprintModifier;
        else if(!isSliding)
            selfRigidBody.linearVelocity = moveDirection * moveSpeed;
    }
    
    private void Slide()
    {
        isSlideCooldown = true;
        isSliding = true;
        moveDirection.Normalize();
        selfRigidBody.AddForce(moveDirection * slideSpeed);
        StartCoroutine(StopSlide());
    }
    private void UpdateCamera()
    {
        if(isSliding)
            cameraScript.ZoomCamera(60f, 15f);
        else if(Input.GetKey(KeyCode.LeftShift))
            cameraScript.ZoomCamera(66f, 15f);
        else 
            cameraScript.ZoomCamera(64f, 15f);
    }
    IEnumerator StopSlide()
    {
        yield return new WaitForSeconds(slideCoolDown);
        isSliding = false;
        StartCoroutine(StartCooldown());
    }
    IEnumerator StartCooldown()
    {
        Debug.Log("cooldown on");
        yield return new WaitForSeconds(slideCoolDown);
        isSlideCooldown = false;
    }
    IEnumerator TakeDamageFlash(SpriteRenderer sprite, int count)
    {
        for(int i = 0; i < count; i++)
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public override void OnTakeDamage()
    {
        for(int i =0; i <playerSprites.Length; i++)
        {
            StartCoroutine(TakeDamageFlash(playerSprites[i],2));
        }
    }
}