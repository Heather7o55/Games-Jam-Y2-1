using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    public InputActionReference moveAction;
    public float speed = 5f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction.action.Enable();
    }

    void FixedUpdate()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        rb.linearVelocity = input * speed;
    }
}
