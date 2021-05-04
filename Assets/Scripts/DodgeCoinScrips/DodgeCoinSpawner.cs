using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCoinSpawner : MonoBehaviour {
    // This goes on the coin and handles all coin related behavior
    [SerializeField] private float startForce = 5.0f;
    [SerializeField] private float maxStartAngle = 0.8f;
    [SerializeField] private float maxMagnitude;
    [SerializeField] private float minMagnitude;
    [SerializeField] private List<GameObject> coinPool;
    //[SerializeField] private GameManager gameManager;

    private LayerMask wallLayer;
    private LayerMask playerLayer;
    private Rigidbody2D rBody;
    private int currentNumCoins =0;

    #region Properties

    #endregion

    #region MonoBehavior

    private void Awake() {
        rBody = GetComponent<Rigidbody2D>();
        wallLayer = LayerMask.NameToLayer("Wall");
        playerLayer = LayerMask.NameToLayer("Player");
       
    }

    private void FixedUpdate() {
       // AdjustMagnitude();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == playerLayer) {
            GameOver();
            Debug.Log("game over");
        }
        if (collision.gameObject.layer == wallLayer) {
            // do stuff here, maybe audio noises?
        }
    }

    private void GameOver() {
        // gameManager.GameOver();
        currentNumCoins = 0;
    }

    #endregion

    #region Methods
    public void StartCoin() {
        SpawnCoin();
        LaunchCoin();
        
    }

    private void SpawnCoin() {
        int startPosX = (UnityEngine.Random.Range(-600, 600));
        int startPosY = (UnityEngine.Random.Range(-500, 500));
        Vector2 dir = new Vector2(startPosX, startPosY);
        Instantiate(coinPool[currentNumCoins], dir, Quaternion.identity);
        currentNumCoins++;
       
    }

    private void LaunchCoin() {
        float startDir = (UnityEngine.Random.value >= 0.5f) ? 1f : -1f;
        float startAngle = UnityEngine.Random.Range(-maxStartAngle, maxStartAngle);

        Vector2 dir = new Vector2(startDir, startAngle);
        rBody.velocity = dir * startForce;
    }
    private void AdjustMagnitude() {
        if (rBody.velocity.magnitude > maxMagnitude) {
            rBody.velocity = Vector2.ClampMagnitude(rBody.velocity, maxMagnitude);
        }
        if (rBody.velocity.magnitude < minMagnitude) {
            rBody.AddForce(rBody.velocity * 2f);
        }
    }

    #endregion


}
