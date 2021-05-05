using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] private AudioSource speaker;
    [SerializeField] private AudioSource gameOverSpeaker;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private GameManager gameManager;

    private void Start() {
    }

    private void Update() {
    }

    public void StartBackgroundMusic(GameState currentState) {
        if (currentState == GameState.Playing) {
            speaker.clip = backgroundMusic;
            speaker.Play();
        }
        if (currentState == GameState.GameOver) {
            gameOverSpeaker.clip = gameOver;
            gameOverSpeaker.Play();
        }
    }
}