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
        private int initialLevel;

        [SerializeField]
        private int resetLevel;

        [SerializeField]
        private float speedIncrease = 0.0f;

        [SerializeField]
        private List<JSButton> gameButtons;

        [SerializeField]
        private AudioSource speaker;

        private List<JSButton> orderToMatch;

        private int currentIndex;
        private float pauseBetweenLevels = 2.0f;

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
            gameLevel = initialLevel;
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
            yield return new WaitForSeconds(pauseBetweenLevels);
            foreach (var button in buttons) {
                ActivateButton(button);
                yield return waitTime;
            }
            currentMode = GameMode.Receiving;
        }

        public void ActivateButton(JSButton selectedButton) {
            selectedButton.ButtonAnimation.Play();
            PlayButtonAudio(selectedButton);
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
            currentIndex = 0;
            gameLevel++;
            currentMode = GameMode.PlayingBack;
            AddRandomButton();
            StartGame();
        }

        private void PlayButtonAudio(JSButton buttonToPlay) {
            speaker.clip = buttonToPlay.ButtonAudioClip;
            speaker.Play();
        }
    }
}