using System;
using SOEvents.Events;
using UnityEngine;

namespace SpeedDot {
    [RequireComponent(typeof(LineRenderer))]
    public class SpeedDotConnector2D : MonoBehaviour {
        private LineRenderer renderOfLines;

        private void Awake() {
            renderOfLines = GetComponent<LineRenderer>();
        }

        public void DrawToNext(SpeedDot nextDot) {
            if(nextDot.HasBeenClicked == false) {
                int lineIndex = renderOfLines.positionCount;
                renderOfLines.positionCount++;
                renderOfLines.SetPosition(lineIndex, nextDot.transform.position);
            }
        }
    }
}
