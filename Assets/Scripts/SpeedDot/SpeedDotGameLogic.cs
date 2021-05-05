using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedDot {

    
    public class SpeedDotGameLogic : MonoBehaviour {
        // Definitely could be done better, "don't @ me."
        public GameObject menuManager;
        private SpeeddotMainMenu SDMenuMan;
        //==========================================

        private enum GameMode {
            NONE, PlayingBack, Receiving
        }

        [SerializeField]
        private int gameLevel = 2;

        [SerializeField]
        private int initialLevel;

        [SerializeField]
        private float speedIncrease = 0.0f;

        [SerializeField]
        private Transform dotsContainer;
        [SerializeField]
        private List<SpeedDot> dotsToConnect;

        [SerializeField]
        private SpeedDotConnector2D lineConnector;

        private float pauseBetweenLevels = 1.5f;
        private List<SpeedDot> gameDots;

        private GameMode currentMode = GameMode.NONE;

        private void Start() {
            Debug.Log("Game Starting");
            PopulateGameDotsList();
            ResetGame();
            AddRandomDots(gameLevel);
            StartCoroutine(PlayButtonSequence(dotsToConnect, speedIncrease));
            Debug.Log("Game Starting Finished");
        }

        private void PopulateGameDotsList() {
            Debug.Log("Populate gameDots list start");
            gameDots = new List<SpeedDot>();
            SpeedDot dotToAdd;
            foreach (Transform child in dotsContainer) {
                dotToAdd = child.GetComponent<SpeedDot>();
                if (dotToAdd != null) {
                    gameDots.Add(dotToAdd);
                }
            }
        }

        private void ResetGame() {
            currentMode = GameMode.PlayingBack;
            dotsToConnect = new List<SpeedDot>();
            gameLevel = initialLevel;

            ResetDots();
        }

        public void StartGame() {
            StartCoroutine(PlayButtonSequence(dotsToConnect, speedIncrease));
            Debug.Log("StartGame() in speeddot gamelogic fired");
        }

        private void AddRandomDot() {
            int buttonToAdd = UnityEngine.Random.Range(0, gameDots.Count);
            if (dotsToConnect.Contains(gameDots[buttonToAdd])) {
                AddRandomDot();
            } else {
                dotsToConnect.Add(gameDots[buttonToAdd]);
            }
        }

        private void AddRandomDots(int numToAdd) {
            for (int i = 0; i < numToAdd; i++) {
                AddRandomDot();
            }
        }

        private void GameOver() {
            SDMenuMan = menuManager.GetComponent<SpeeddotMainMenu>();

            // Game Manager Broadcast Game Over
            //ResetGame();
            Debug.Log("Game Over moving to highscore table.");

            //Game Manager tells Menu manager to send score over to leaderboard. Renders leaderboad. 
            SDMenuMan.EndGametoHighScore();

            
        }

        public void DebugGameOver()
        {
            GameOver();
        }

        private IEnumerator PlayButtonSequence(List<SpeedDot> dots, float pauseTime) {
            currentMode = GameMode.PlayingBack;
            WaitForSeconds waitTime = new WaitForSeconds(pauseTime);
            yield return new WaitForSeconds(pauseBetweenLevels);
            for (int i = 0; i < dots.Count; i++) {
                dots[i].gameObject.SetActive(true);
                if (i < dots.Count - 1) {
                    yield return waitTime;
                }
            }
            currentMode = GameMode.Receiving;
        }

        private void NextLevel() {
            Debug.Log("Next Level");

            gameLevel++;
            currentMode = GameMode.PlayingBack;
            ResetDots();
            AddRandomDots(gameLevel);
            StartGame();
        }

        public void RegisterSpeedDotClick(SpeedDot dot) {
            if (currentMode == GameMode.Receiving) {
                if (!dot.HasBeenClicked) {
                    dot.HasBeenClicked = true;
                    lineConnector.DrawToNext(dot);
                    ChangeColor(dot);
                }

                if (AreAllDotsClicked()) {
                    NextLevel();
                }
            }
        }

        private void ChangeColor(SpeedDot dot) {
            var dotRenderer = dot.GetComponent<Renderer>();
            dotRenderer.material.SetColor("_Color", Color.cyan);
        }

        private bool AreAllDotsClicked() {
            for (int i = 0; i < dotsToConnect.Count; i++) {
                if (!dotsToConnect[i].HasBeenClicked) { return false; }
            }
            return true;
        }

        private void ResetDots() {
            lineConnector.ClearLines();
            dotsToConnect = new List<SpeedDot>();
            for (int i = 0; i < gameDots.Count; i++) {
                gameDots[i].gameObject.SetActive(false);
                gameDots[i].HasBeenClicked = false;
            }
        }
    }
}