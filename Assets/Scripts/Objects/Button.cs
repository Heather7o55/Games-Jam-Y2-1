using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeAlloted = 5;
    public string[] tags;
    float sec;
    public GameObject hiddenDoor;
    private Renderer[] renderers;

    void Update()
    {
        if(sec <= timeAlloted)
        { 
            ChangeColor(new Color (0.5f, 0, 0, 1));
            hiddenDoor.SetActive(false);
            sec += 1*Time.deltaTime;
            Debug.Log(sec); 
        }
        else
        {
            ChangeColor(new Color (1, 0, 0, 1));
            hiddenDoor.SetActive(true);
        }
    }
    void Start()
    {
        sec = timeAlloted;
        renderers = GetComponentsInChildren<Renderer>();
        ChangeColor(new Color (1, 0, 0, 1));
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        for(int i = 0; i < tags.Length; i++)
        {
            if(collider.CompareTag(tags[i]))
            {
                sec = 0;
            }
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
