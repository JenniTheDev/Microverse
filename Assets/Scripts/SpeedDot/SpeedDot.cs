using SOEvents.Events;
using UnityEngine;

namespace SpeedDot {
    public class SpeedDot : MonoBehaviour {
        [SerializeField]
        private SOEvents.Events.GameEventSpeedDot onClick;
        [SerializeField] private Animation dotAnimation;

        public bool HasBeenClicked { get; set; } = false;
        public Animation DotAnimation { get => dotAnimation; }

        #region MonoBehaviour
        private void OnMouseDown() {
            this.onClick?.Raise(this);
        }
        #endregion

        #region Class Methods

        #endregion
    }
}