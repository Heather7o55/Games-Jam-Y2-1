using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController2D : MonoBehaviour
{
    public InputActionReference moveAction;
    public InputActionReference sprintAction;
    public InputActionReference attackAction;

    public float walkSpeed = 5f;
    public float sprintMultiplier = 2f;

    Rigidbody2D rb;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        moveAction.action.Enable();
        sprintAction.action.Enable();
        attackAction.action.Enable();
    }

    void FixedUpdate()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        bool isSprinting = sprintAction.action.ReadValue<float>() > 0.5f;
        float speed = walkSpeed * (isSprinting ? sprintMultiplier : 1f);

        rb.linearVelocity = input * speed;

        animator.SetBool("isMoving", input != Vector2.zero);
    }

    void Update()
    {
        if (attackAction.action.triggered)
        {
            animator.SetTrigger("Attack");
        }
    }
}
