using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
   // public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    
    [SerializeField] private List<GameObject> coinPool;
    [SerializeField] private int numOfCoins;


    //REFERENCE VIDEO https://www.youtube.com/watch?v=1h2yStilBWU&t=213s

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoin", spawnTime, spawnDelay);
    }

    private void FixedUpdate() {
        
        
    }

    
    public void SpawnCoin()
    {
        
        Instantiate(coinPool[numOfCoins], transform.position, transform.rotation);
        numOfCoins++;
        
        if (stopSpawning)
        {
            CancelInvoke("SpawnCoin");
        }
    }
}