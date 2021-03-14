// Jenni
using System;
using System.Collections.Generic;
using UnityEngine;

public class JSGameLogic : MonoBehaviour {

    // List of buttons in the game 
    [SerializeField] private List<GameObject> gameButtons;
    // list that is empty, but filled as the computer selects a button
    [SerializeField] private List<GameObject> orderToMatch;
    // list of buttons pressed
    [SerializeField] private List<GameObject> playerChoices;
    // Can't push buttons while the game is playing
    private bool inputEnabled = false;
    private bool gameFailed = false;
    // inrement after every successful pattern picked
    private int gameLevel = 0;
    
    

    void Start() {
        
    }

    private void Update() {
        
    }

    private void ResetButtons() {

    }

    private void PickOrderToSay() {

    }

    private void PlayerGuesses() {
        inputEnabled = true;

    }

    private void CheckOrder() {

    }



}