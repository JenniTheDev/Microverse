using System.Collections.Generic;
using UnityEngine;

namespace SpeedDot {
    public class LineController : MonoBehaviour {
        [SerializeField] private List<Transform> pointsToConnect;
        private LineRenderer lineBetweenPoints;

        private void Start() {
            lineBetweenPoints = GetComponent<LineRenderer>();
        }

        private void Update() {
            DrawLines();
        }

        // touch button, one location
        // touch button, two locations, draw line
        // touch button, three locations, draw next line
        // if (n-1), draw line ?
        public void GetButtonLocation(JSButton selectedButton) {
           pointsToConnect.Add(selectedButton.gameObject.transform);
        }
        // ON click draw line? 
        private void DrawLines() {
            for (int i = 0; i < pointsToConnect.Count; i++) {
                lineBetweenPoints.SetPosition(i, pointsToConnect[i].position);
            }
        }
    }
}