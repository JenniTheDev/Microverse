// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JSGameLogic : MonoBehaviour {

    // List of buttons in the game
    [SerializeField] private List<GameObject> gameButtons;

    // list that is empty, but filled as the computer selects a button
    // maybe these two lists can just be ints?
    [SerializeField] private List<GameObject> orderToMatch;

    // list of buttons pressed
    [SerializeField] private List<GameObject> playerChoices;

    // Can't push buttons while the game is playing
    private bool inputEnabled = false;

    private bool gameFailed = false;

    // inrement after every successful pattern picked
    private int gameLevel = 0;

    [SerializeField] private int maxGameLevel = 50;

    [SerializeField] private float increasePerLevel = 0.0f;
    [SerializeField] private Animator buttonAnimation;
    [SerializeField] private InputAction input;

    private void Start() {
        // ResetButtons();
        buttonAnimation.Play("ActiveButton");
    }

    private void Update() {
    }

    private void ResetButtons() {
        orderToMatch = new List<GameObject>();
        playerChoices = new List<GameObject>();
        gameFailed = false;
        gameLevel = 1;
        PickOrderToSay();
        //input.
    }

    private void StartGame() {
        StartCoroutine(PlayButtonSequence(orderToMatch, increasePerLevel));
    }

    private void PickOrderToSay() {
        int buttonToAdd;
        for (int i = 0; i < maxGameLevel; i++) {
            buttonToAdd = UnityEngine.Random.Range(0, gameButtons.Count - 1);
            orderToMatch.Add(gameButtons[buttonToAdd]);
        }
    }

    private void PlayerGuesses() {
        inputEnabled = true;
        // On click add button to list
        // on click could add button number to a list
    }

    private void AddPlayerGuess() {
        // Can I pass in the game object, or a id or a tag?
        // playerChoices.Add(theButtonTheyClicked);
    }

    private bool CheckOrder() {
        bool result = false;
        for (int i = 0; i < orderToMatch.Count; i++) {
            result = orderToMatch[i] == playerChoices[i];
            if (result) { continue; } else { return false; }
        }

        return result;
    }

    //private bool DidWeWinYet() {
    //    if (CheckOrder() == false) {
    //        return false;
    //        //broadcast game over
    //    } else {
    //        // continue on with Jenni picking
    //        return true;
    //    }
    //}

    private IEnumerator PlayButtonSequence(List<GameObject> buttons, float pauseTime) {
        WaitForSeconds waitTime = new WaitForSeconds(pauseTime);
        for (int i = 0; i < gameLevel; i++) {
            yield return waitTime;
        }
    }

    private void ActivateButton(GameObject selectedButton) {
        selectedButton.GetComponent<Animator>().Play("Highlighted");
    }
}