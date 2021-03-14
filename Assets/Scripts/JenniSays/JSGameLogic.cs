// Jenni
using System;
using System.Collections.Generic;
using UnityEngine;

public class JSGameLogic : MonoBehaviour {
    // I don't think I need this
    // [SerializeField] private GameObject gameButtonPrefab;
    [SerializeField] private List<ButtonSetting> buttonSettings;
    private Transform gameFieldLayout;

    [SerializeField]private List<GameObject> gameButtons;
    private int numberOfClicks = 0;

    [SerializeField] private List<int> jenniSaid;
    [SerializeField] private List<int> playerSaid;

    System.Random rg;

    private bool inputEnabled = false;
    private bool gameOver = false;

    
    private void Start() {
        InitalizeGameBoard();
    }

    private void InitalizeGameBoard() {
        gameButtons = new List<GameObject>();
        
        

    }

    private void Update() {
    }
}