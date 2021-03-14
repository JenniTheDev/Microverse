// Jenni
using System;
using System.Collections.Generic;
using UnityEngine;

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

    
    
    

    void Start() {
        ResetButtons();
    }

    private void Update() {
        
        // Start Coroutine? 
    }

    private void ResetButtons() {
        orderToMatch = new List<GameObject>();
        playerChoices = new List<GameObject>();
        gameFailed = false;
        gameLevel = 0;
    }

    private void PickOrderToSay() {
        gameLevel++;
        // randomly pick a number 0 - listcount
        // find button in original list order
        // do something to light up / change color of button button
        // add that to picked list
        

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

    private void DidWeWinYet() {
        if (CheckOrder() == false) {
            gameFailed = true;
            //broadcast game over
        } else {
            // continue on with Jenni picking
        }
    }

   


}