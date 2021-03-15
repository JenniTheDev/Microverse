using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference Video: https://www.youtube.com/watch?v=whzomFgjT50

    public float movementSpeed = 200f;

    public Rigidbody2D dogeRB;

    //can store x and y movement
    Vector2 movement;


    // Will handle input
    void Update()
    {
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
}
