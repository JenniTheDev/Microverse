using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //Reference Video: https://www.youtube.com/watch?v=whzomFgjT50

    public float movementSpeed = 200f;

    public bool collided = false;

    private Rigidbody2D dogeRB;

    //can store x and y movement
    private Vector2 movement;

    private LayerMask coinLayer;
    [SerializeField] private GameManager gameManager;

    private void Start() {
        coinLayer = LayerMask.NameToLayer("Coin");
        dogeRB = GetComponent<Rigidbody2D>();
    }

    // Will handle input
    public void Update() {
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
    private void FixedUpdate() {
        //fixedDeltaTime used to make sure movement stays the same no matter how many times
        //FixedUpdate is called
        dogeRB.MovePosition(dogeRB.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == coinLayer) {
            gameManager.EndGame();
        }
    }
}