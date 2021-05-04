using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    //REFERENCE VIDEO https://www.youtube.com/watch?v=1h2yStilBWU&t=213s

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoin", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    public void SpawnCoin()
    {
        
        Instantiate(spawnee, transform.position, transform.rotation);
        
        if (stopSpawning)
        {
            CancelInvoke("SpawnCoin");
        }
    }
}