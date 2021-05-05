using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Touch Control Variables
    private Vector3 touchPosition;

    private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField] private float moveSpeed = 10.0f;
    private Touch touch;
    private LayerMask coinLayer;
    [SerializeField] private GameManager gameManager;

    // PC Control Variables
    //Reference Video: https://www.youtube.com/watch?v=whzomFgjT50

    public float movementSpeed = 200f;
    public bool collided = false;

    //public Rigidbody2D dogeRB;
    private Vector2 movement;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        coinLayer = LayerMask.NameToLayer("Coin");

        //#if UNITY_STANDALONE || UNITY_WEBPLAYER

        //#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        //        rb = GetComponent<Rigidbody2D>();
        //        coinLayer = LayerMask.NameToLayer("Coin");
    }

    private void Update() {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        //returns a value from -1 to 1: -1 = left, 0 = idle, 1 = right
        movement.x = Input.GetAxisRaw("Horizontal");
        //returns a value from -1 to 1: -1 = down, 0 = idle, 1 = up
        movement.y = Input.GetAxisRaw("Vertical");
        dogeRB.MovePosition(dogeRB.position + movement * movementSpeed * Time.fixedDeltaTime);

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
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

#endif //End of mobile platform dependendent compilation section started above with #elif

    private void FixedUpdate() {
        //fixedDeltaTime used to make sure movement stays the same no matter how many times
        //FixedUpdate is called
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == coinLayer) {
            gameManager.EndGame();
        }
    }
}