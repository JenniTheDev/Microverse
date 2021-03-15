using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JenniSays {
    public class JenniSaysGameManager : MonoBehaviour {
        [SerializeField] private GameState currentState = GameState.None;
        [SerializeField] private GameObject startButton;
        [SerializeField] private GameObject exitToMenuButton;
        [SerializeField] private GameObject restartGame;

        public GameState CurrentState {
            get { return this.currentState; }
            set { this.currentState = value; }
        }

        // GameStates
        // Intro - directions with start button
        // Playing - playing the game loop
        // Game Over - display score, restart game and exit to menu buttons
        #region MonoBehavior

        private void Start() {
        
            Subscribe();
            currentState = GameState.Intro;
            
            // something to turn off all the game objects
            startButton.SetActive(true);
            exitToMenuButton.SetActive(false);
            restartGame.SetActive(false);
           
        }

        private void OnEnable() {
            Subscribe();
        }

        private void OnDisable() {
            Unsubscribe();
        }

        #endregion MonoBehavior

        #region Methods

        public void PlayGame() {
            // turn on game objects
            currentState = GameState.Playing;
            startButton.SetActive(false);
            restartGame.SetActive(false);
            exitToMenuButton.SetActive(false);
        }

        public void EndGame() {
            currentState = GameState.GameOver;
            startButton.SetActive(false);
            exitToMenuButton.SetActive(true);
            restartGame.SetActive(true);
        }

        private void Subscribe() {
            Unsubscribe();
        }

        private void Unsubscribe() {
        }

        #endregion Methods
    }

}
