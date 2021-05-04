using System.Collections.Generic;
using UnityEngine;
using Variables;

public class SpawnCoins : MonoBehaviour {
    [SerializeField] private List<GameObject> coinPool;
    [SerializeField] private float spawnDelay = 0.1f;
    [SerializeField] private float spawnTime = 5f;

    [SerializeField]private bool stopSpawning;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private IntVariable coinsSurvived;

    //REFERENCE VIDEO https://www.youtube.com/watch?v=1h2yStilBWU&t=213s

    private void Start() {
        StartGame();
    }

    private void StartGame() {
        coinsSurvived.IntValue = 0;
        stopSpawning = false;
        InvokeRepeating("SpawnCoin", spawnTime, spawnDelay);
    }

    public void SpawnCoin() {
        coinPool[coinsSurvived.IntValue].SetActive(true);
        //Instantiate(coinPool[coinsSurvived.IntValue], transform.position, transform.rotation);

        coinsSurvived.IntValue++;
        if (coinsSurvived.IntValue++ == coinPool.Count - 1) {
            gameManager.EndGame();
        }

        if (stopSpawning) {
            CancelInvoke("SpawnCoin");
        }
    }

    public void GameOver(GameState currentState) {
        if (currentState == GameState.GameOver) {
            ResetCoins();
        }
    }

    public void RestartGame(GameState currentState) {
        if (currentState == GameState.Playing) {
           // ResetCoins();
            stopSpawning = false;
            StartGame();
        }
    }

    private void ResetCoins() {
        stopSpawning = true;
        coinsSurvived.IntValue = 0;
        foreach (var coin in coinPool) {
            coin.gameObject.SetActive(false);
        }
    }
}