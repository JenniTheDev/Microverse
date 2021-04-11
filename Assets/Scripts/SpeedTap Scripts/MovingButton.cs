using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingButton : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private RectTransform rectT; 
   
    Vector2 targetPosition;

    

    public float moveSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetRandomPosition();
        rectT = GetComponent<RectTransform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLocation();
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY); 
    }
   
    public void UpdateLocation()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }

        
       // Debug.Log(targetPosition);
    }
}
