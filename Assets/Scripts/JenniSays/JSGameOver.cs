// Jenni
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Variables;

namespace JenniSays {
    public class JSGameOver : MonoBehaviour {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private AudioSource speaker;
        [SerializeField] private AudioClip gameOverSound;
        [SerializeField] private IntVariable score;
        [SerializeField] private int finalScore;
        [SerializeField] private TMP_Text finalScoreText;
        private List<int> highScores;

        public void GameOver(GameState currentState) {
            if (currentState == GameState.GameOver) {
                DisplayFinalScore();
                DisplayHighScores();
                PlaySound();
            }
        }

        private void PlaySound() {
            speaker.clip = gameOverSound;
            speaker.Play();
        }

        private void DisplayHighScores() {
        }

        private void DisplayFinalScore() {
            // finalScore = (int)score;
            //finalScore = System.Convert.ToInt32(score);
            // int.TryParse(score, out finalScore);
            //TODO: convert IntVariable to variable?
            finalScoreText.text = $"Final Score {finalScore.ToString()}";
        }
    }
}