using SOEvents.Events;
using UnityEngine.Events;

namespace SOEvents.Listeners {
    public class GameEventListenerSpeedDot
        : BaseGameEventListener<
            SpeedDot.SpeedDot,
            GameEventSpeedDot,
            UnityEvent<SpeedDot.SpeedDot>> { }
}