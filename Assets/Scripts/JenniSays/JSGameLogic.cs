// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JenniSays {
    public class JSGameLogic : MonoBehaviour {

        // List of buttons in the game
        [SerializeField] private List<GameObject> gameButtons;

        // list that is empty, but filled as the computer selects a button
        // maybe these two lists can just be ints?
        [SerializeField] private List<GameObject> orderToMatch;

        // Can't push buttons while the game is playing
        private bool inputEnabled = false;

        // inrement after every successful pattern picked
        private int gameLevel = 1;

        [SerializeField] private float speedIncrease = 0.0f;
        [SerializeField] private Animator buttonAnimation;
        [SerializeField] private InputAction input;

        private void Start() {
            ResetButtons();
        }

        private void Update() {
        }

        private void ResetButtons() {
            orderToMatch = new List<GameObject>();
            gameLevel = 1;
            OrderToSay();
        }

        private void StartGame() {
            StartCoroutine(PlayButtonSequence(orderToMatch, speedIncrease));
        }

        private void OrderToSay() {
            int buttonToAdd = UnityEngine.Random.Range(0, gameButtons.Count - 1);
            orderToMatch.Add(gameButtons[buttonToAdd]);
        }

        private void IsPlayerCorrect() {
            inputEnabled = true;
            for (int i = 0; i < gameLevel; i++) {
                // player input collected button click listener? Event passing parameter?
                // player input != to orderToMatch[i];
                //  return false ;
            } // return true;
        }

        private void OnGameButtonClick() {
            if (!inputEnabled) {
                return;
            }
        }

        private IEnumerator PlayButtonSequence(List<GameObject> buttons, float pauseTime) {
            inputEnabled = false;
            GameObject showButton;
            WaitForSeconds waitTime = new WaitForSeconds(pauseTime);
            for (int i = 0; i < gameLevel; i++) {
                showButton = buttons[i];
                ActivateButton(showButton);
                yield return waitTime;
            }
        }

        private void ActivateButton(GameObject selectedButton) {
            selectedButton.GetComponent<Animator>().Play("ActiveButton");
        }
    }
}