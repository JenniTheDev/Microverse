using SOEvents.Events;
using UnityEngine;

namespace SpeedDot {
    public class SpeedDot : MonoBehaviour {
        [SerializeField]
        private SOEvents.Events.GameEventSpeedDot onClick;

        public bool HasBeenClicked { get; set; } = false;

        #region MonoBehaviour
        private void OnMouseDown() {
            this.onClick?.Raise(this);
            HasBeenClicked = true;
        }
        #endregion

        #region Class Methods

        #endregion
    }
}