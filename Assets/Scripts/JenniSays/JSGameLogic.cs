// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JenniSays {
    public class JSGameLogic : MonoBehaviour {

        private enum GameMode {
            NONE, PlayingBack, Receiving
        }

        [SerializeField]
        private int gameLevel = 1;

        [SerializeField]
        private float speedIncrease = 0.0f;

        [SerializeField]
        private List<JSButton> gameButtons;

        private List<JSButton> orderToMatch;

        private int currentIndex;

        private GameMode currentMode = GameMode.NONE;

        private void Start() {
            ResetGame();
            AddRandomButtons(gameLevel);
            StartCoroutine(PlayButtonSequence(orderToMatch, speedIncrease));
        }

        private void Update() {
        }

        private void ResetGame() {
            currentMode = GameMode.PlayingBack;
            orderToMatch = new List<JSButton>();
            gameLevel = 1;
            currentIndex = 0;
        }

        private void StartGame() {
            StartCoroutine(PlayButtonSequence(orderToMatch, speedIncrease));
        }

        private void AddRandomButton() {
            int buttonToAdd = UnityEngine.Random.Range(0, gameButtons.Count);
            orderToMatch.Add(gameButtons[buttonToAdd]);
        }

        private void AddRandomButtons(int numToAdd) {
            for (int i = 0; i < numToAdd; i++) {
                AddRandomButton();
            }
        }

        private void GameOver() {
            // Game Manager Broadcast Game Over
            ResetGame();
            Debug.Log("Start Over");
        }

        private IEnumerator PlayButtonSequence(List<JSButton> buttons, float pauseTime) {
            currentMode = GameMode.PlayingBack;
            WaitForSeconds waitTime = new WaitForSeconds(pauseTime);
            foreach (var button in buttons) {
                ActivateButton(button);
                yield return waitTime;
            }
            currentMode = GameMode.Receiving;
        }

        public void ActivateButton(JSButton selectedButton) {
            selectedButton.ButtonAnimation.Play();
            if (this.currentMode == GameMode.Receiving && currentIndex < orderToMatch.Count) {
                if (selectedButton == orderToMatch[currentIndex]) {
                    Debug.Log("Match");
                    currentIndex++;
                } else {
                    GameOver();
                }
            }
            if (currentIndex == orderToMatch.Count && currentIndex != 0) {
                NextLevel();
            }
        }

        private void NextLevel() {
            Debug.Log("Next Level");
            PauseBetweenLevels();
            currentIndex = 0;
            gameLevel++;
            currentMode = GameMode.PlayingBack;
            AddRandomButton();
            StartGame();
        }

        private IEnumerator PauseBetweenLevels() {
            int pauseTime = 5;
            yield return new WaitForSecondsRealtime(pauseTime);
        }
    }
}

