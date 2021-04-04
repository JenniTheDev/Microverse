using System.Collections.Generic;
using UnityEngine;

namespace SpeedDot {
    public class LineController : MonoBehaviour {
        [SerializeField]private List<Transform> pointsToConnect;
        [SerializeField] private LineRenderer lineBetweenPoints;

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

        public void SetUpLine(List<Transform> points) {
            lineBetweenPoints.positionCount = pointsToConnect.Count;
            this.pointsToConnect = points;
        }
        

        private void DrawLines() {
            lineBetweenPoints.positionCount = pointsToConnect.Count;
            for (int i = 0; i < pointsToConnect.Count; i++) {
                lineBetweenPoints.SetPosition(i, pointsToConnect[i].position);
            }
        }
    }
}