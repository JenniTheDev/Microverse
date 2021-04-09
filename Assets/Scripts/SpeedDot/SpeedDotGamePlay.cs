using System.Collections.Generic;
using UnityEngine;

namespace SpeedDot {
    public class SpeedDotGameplay : MonoBehaviour {

        // event for level change
        [SerializeField]
        private List<SpeedDot> allDots;

        private List<SpeedDot> dotsToMatch;

        [SerializeField]
        private int gameLevel = 0;

        [SerializeField]
        private int initalLevel;

        [SerializeField]
        private int resetLevel;

        private int randomIndex;

        private void Start() {
            ResetGame();
            NextLevel();
        }

        private void Update() {
             
        }

        private void PlayGame() {
            SetUpDots();
            
        }

        private void ResetGame() {
            gameLevel = initalLevel;
        }



        private void AddDot(SpeedDot clickedButton) {
            //clickedButton.ButtonAnimation.Play();
           // clickedDots.Add(clickedButton);
        }

        private void SetUpDots() {
            for (int i = 0; i < gameLevel + 1; i++) {
                randomIndex = Random.Range(0, allDots.Count);
                if (!allDots[randomIndex].gameObject.activeSelf) {
                    allDots[randomIndex].gameObject.SetActive(true);
                } else {
                    i--;
                }
            }
        }

        private void NextLevel() {
            foreach (var dot in dotsToMatch) {
                dot.gameObject.SetActive(false);
            }
            gameLevel++;
        }

        private void CheckList() {
        }
    }
}