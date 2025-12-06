using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsAnimation : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        anim.SetFloat("Input x", moveDirection.x);
        anim.SetFloat("Input y", moveDirection.y);

    }
}
