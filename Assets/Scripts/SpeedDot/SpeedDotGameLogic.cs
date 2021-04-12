using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedDot {
    public class SpeedDotGameLogic : MonoBehaviour {

        private enum GameMode {
            NONE, PlayingBack, Receiving
        }

        [SerializeField]
        private int gameLevel = 2;

        [SerializeField]
        private int initialLevel;

        [SerializeField]
        private int resetLevel;

        [SerializeField]
        private float speedIncrease = 0.0f;

        [SerializeField]
        private List<SpeedDot> gameDots;

        private List<SpeedDot> dotsToConnect;

        private int currentIndex;
        private float pauseBetweenLevels = 1.5f;

        private GameMode currentMode = GameMode.NONE;

        private void Start() {
            ResetGame();
            AddRandomDots(gameLevel);
            StartCoroutine(PlayButtonSequence(dotsToConnect, speedIncrease));
        }

        private void Update() {
        }

        private void ResetGame() {
            currentMode = GameMode.PlayingBack;
            dotsToConnect = new List<SpeedDot>();
            gameLevel = initialLevel;
            currentIndex = 1;  // not sure if this should stay at 1
            foreach (var dot in gameDots) {
                dot.gameObject.SetActive(false);
            }
        }

        private void StartGame() {
            StartCoroutine(PlayButtonSequence(dotsToConnect, speedIncrease));
        }

        private void AddRandomDot() {
            int buttonToAdd = UnityEngine.Random.Range(0, gameDots.Count);
            if (dotsToConnect.Contains(gameDots[buttonToAdd])) {
                AddRandomDot();
            } else {
                dotsToConnect.Add(gameDots[buttonToAdd]);
            }
            // orderToMatch.Add(gameDots[buttonToAdd]);
        }

        private void AddRandomDots(int numToAdd) {
            for (int i = 0; i < numToAdd; i++) {
                AddRandomDot();
            }
        }

        private void GameOver() {
            // Game Manager Broadcast Game Over
            ResetGame();
            Debug.Log("Start Over");
        }

        private IEnumerator PlayButtonSequence(List<SpeedDot> dots, float pauseTime) {
            currentMode = GameMode.PlayingBack;
            WaitForSeconds waitTime = new WaitForSeconds(pauseTime);
            yield return new WaitForSeconds(pauseBetweenLevels);
            foreach (var dot in dots) {
                ActivateDot(dot);
                yield return waitTime;
            }
            currentMode = GameMode.Receiving;
        }

        public void ActivateDot(SpeedDot selectedDot) {
            selectedDot.DotAnimation.Play();
            selectedDot.gameObject.SetActive(true);
            if (this.currentMode == GameMode.Receiving && currentIndex < dotsToConnect.Count) {
                // check if all dots are clicked
               // AreAllDotsClicked();
                //if (selectedDot == dotsToConnect[currentIndex]) {
                //    Debug.Log("Match");
                    currentIndex++;
                //} else {
                //    GameOver();
                //} 
            }
            if (currentIndex == dotsToConnect.Count && currentIndex != 0 && AreAllDotsClicked()) {
                NextLevel();
            }
        }

        private void NextLevel() {
            Debug.Log("Next Level");
            currentIndex = 0;
            gameLevel++;
            currentMode = GameMode.PlayingBack;
            // Set game objects to false
            AddRandomDot();
            StartGame();
        }

        private bool AreAllDotsClicked() {
            foreach (var dot in dotsToConnect) {
                if (dot.HasBeenClicked == false) {
                    Debug.Log("All dots not clicked");
                    return false;
                }
                // Needs a way to return true if all are true   

            }
            Debug.Log("All dots clicked");
            return true;
        }
    }
}