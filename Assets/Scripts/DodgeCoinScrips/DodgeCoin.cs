using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCoin : MonoBehaviour {
    [SerializeField] private float startForce = 5.0f;
    [SerializeField] private float maxStartAngle;
    [SerializeField] private float maxMagnitude;
    [SerializeField] private float minMagnitude;
    //[SerializeField] private GameManager gameManager;

    private LayerMask wallLayer;
    private LayerMask playerLayer;
    private Rigidbody2D rBody;

    #region Properties

    #endregion

    #region MonoBehavior

    private void Awake() {
        rBody = GetComponent<Rigidbody2D>();
        wallLayer = LayerMask.NameToLayer("Wall");
        playerLayer = LayerMask.NameToLayer("Player");
    } 

    public void StartCoin() {
        SpawnCoin();
        LaunchCoin();
        
    }

    private void SpawnCoin() {
        int startPosX = (UnityEngine.Random.Range(-600, 600));
        int startPosY = (UnityEngine.Random.Range(-500, 500));
        Vector2 dir = new Vector2();
       // transform.position = Vector2(startPosX, startPosY);
       // need to make a random spawn position
    }

    private void LaunchCoin() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == playerLayer) {
            // game manager call game over
        }
    }

    #endregion


}
