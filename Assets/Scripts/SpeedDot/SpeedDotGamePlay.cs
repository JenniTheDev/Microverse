using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedDot {
    public class SpeedDotGameplay : MonoBehaviour {

        // event for level change
        [SerializeField]
        private List<SpeedDot> allDots;
        private List<SpeedDot> clickedDots;

        [SerializeField]
        private int gameLevel = 1;

        [SerializeField]
        private int initalLevel;

        [SerializeField]
        private int resetLevel;

        // if all dots clicked are false, next level
        // time up game over

        private void Start() {
            ResetGame();
        }

        private void ResetGame() {
            gameLevel = initalLevel;

        }

        private void AddDot(SpeedDot clickedButton) {
            // clickedButton.ButtonAnimation.Play();
            clickedDots.Add(clickedButton);

        }

        private void DotActivator() {
    
        }
        private void NextLevel() {
            foreach (var dot in clickedDots) {
                // dot.SetActive(false);
            }
            gameLevel++;
        }
        private void CheckList() {

            
        }
    }
}