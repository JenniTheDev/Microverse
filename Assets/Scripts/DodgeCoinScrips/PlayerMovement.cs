using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Reference Video: https://www.youtube.com/watch?v=whzomFgjT50

    public float movementSpeed = 200f;
    //public DogeManager dogeManager;
    public GameObject Panel_gameOver;
    public bool collided = false;

    public Rigidbody2D dogeRB;

    //can store x and y movement
    Vector2 movement;

   
    //if a coin collision is detected set the boolean flag to true
    public void OnCollisionEnter2D(Collision2D col)
   
    {
        //if (this.gameObject.tag== "Player" && col.gameObject.tag == "coin");
        //{
        //    collided = true;
        //}

        // just call game over here
        Debug.Log("game over");
        
    }



   
    // Will handle input
    public void Update()
    {
        // This can be handled on coin
        ////checks to see if a collision happens with a coin
        //if(collided)
        //{
        //    Panel_gameOver.SetActive(true);
        //    Time.timeScale = 0;
        //}
        

        
        //returns a value from -1 to 1: -1 = left, 0 = idle, 1 = right
        movement.x = Input.GetAxisRaw("Horizontal");
        //returns a value from -1 to 1: -1 = down, 0 = idle, 1 = up
        movement.y = Input.GetAxisRaw("Vertical");
    }

    //method to update movement
    void FixedUpdate()
    {
        //fixedDeltaTime used to make sure movement stays the same no matter how many times
        //FixedUpdate is called
        dogeRB.MovePosition(dogeRB.position + movement * movementSpeed * Time.fixedDeltaTime);
    }





    public void restartDogeGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("dodgecoin_ui");
    }
}
