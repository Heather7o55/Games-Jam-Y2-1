using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject hiddenDoor;
    [SerializeField] private Animator anim1 = null;
    [SerializeField] private Animator anim2 = null;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") || collider.CompareTag("Enemy"))
        {
            anim1.Play("dooropen");
            anim2.Play("dooropen1");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") || collider.CompareTag("Enemy"))
        {
            anim1.Play("doorclose");
            anim2.Play("doorclose1");
        }
    }
    public void ChangeColor(Color color)
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = color;
        }
    }
}
