using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTouch : MonoBehaviour
{
    // https://www.youtube.com/watch?v=ST7BAqV-1ow

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField]private float moveSpeed = 10.0f;
    private Touch touch;
    private LayerMask coinLayer;
    [SerializeField] private GameManager gameManager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coinLayer = LayerMask.NameToLayer("Coin");
    }

   
    void Update()
    {
        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (touch.phase == TouchPhase.Ended) {
                rb.velocity = Vector2.zero;
            }

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == coinLayer) {
            gameManager.EndGame();
        }
    }
}
