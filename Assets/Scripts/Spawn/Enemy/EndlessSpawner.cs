using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    private float spawnInterval = 2f;
    private float minimumSpawnInterval =1f;
    private float intervalDecrease = 0.1f;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            // Here we try catch here, as we may want to know if we've failed to attach a spawnpoint or enemy to the spawner.
            try
                {Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);}
            catch(Exception error)
                {Debug.LogError(error);}
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = MathF.Max(minimumSpawnInterval, spawnInterval = intervalDecrease);
        }
    }
}
