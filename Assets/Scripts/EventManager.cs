// Jenni
using UnityEngine;

public class EventManager {
    #region Singleton
    private static bool isQuitting = false;
    private static EventManager instance = null;

    public static EventManager Instance {
        get {
            if (instance == null && !isQuitting) {
                instance = new EventManager();
                Application.quitting += () => isQuitting = true;
            }
            return instance;
        }
    }

    private EventManager() {
    }

    #endregion Singleton
}