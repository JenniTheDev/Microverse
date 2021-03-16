// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JenniSays {
    public class JSGameLogic : MonoBehaviour {
        enum GameMode {
            NONE, PlayingBack, Receiving
        }

        [SerializeField]
        private int intGameLevel;

        [SerializeField]
        private float speedIncrease = 0.0f;

        // List of buttons in the game
        [SerializeField]
        private List<JSButton> gameButtons;

        // list that is empty, but filled as the computer selects a button
        // maybe these two lists can just be ints?
        private List<JSButton> orderToMatch;

        // Can't push buttons while the game is playing
        private bool inputEnabled = false;

        // inrement after every successful pattern picked
        private int gameLevel = 1;

        private GameMode currentMode = GameMode.NONE;

        private void Start() {
            ResetButtons();
            AddRandomButtons(intGameLevel);
            StartCoroutine(PlayButtonSequence(orderToMatch, speedIncrease));
        }

        private void Update() {
        }

        private void ResetButtons() {
            orderToMatch = new List<JSButton>();
            gameLevel = 1;

        }

        private void StartGame() {
            StartCoroutine(PlayButtonSequence(orderToMatch, speedIncrease));
        }


        private void AddRandomButton() {
            int buttonToAdd = UnityEngine.Random.Range(0, gameButtons.Count);
            orderToMatch.Add(gameButtons[buttonToAdd]);
        }

        private void AddRandomButtons(int numToAdd) {
            for(int i = 0; i < numToAdd; i++) {
                AddRandomButton();
            }
        }

        private void IsPlayerCorrect() {
            inputEnabled = true;
            for(int i = 0; i < gameLevel; i++) {
                // player input collected button click listener? Event passing parameter?
                // player input != to orderToMatch[i];
                //  return false ;
            } // return true;
        }

        private void OnGameButtonClick() {
            if(!inputEnabled) {
                return;
            }
        }

        private IEnumerator PlayButtonSequence(List<JSButton> buttons, float pauseTime) {
            currentMode = GameMode.PlayingBack;
            WaitForSeconds waitTime = new WaitForSeconds(pauseTime);
            foreach(var button in buttons) {
                ActivateButton(button);
                yield return waitTime;
            }
            currentMode = GameMode.NONE;
        }

        public void ActivateButton(JSButton selectedButton) {
            selectedButton.ButtonAnimation.Play();
            if(this.currentMode == GameMode.Receiving) {

            }
            // Debug.Log($"Button {selectedButton.gameObject.name}");
        }


    }
}
