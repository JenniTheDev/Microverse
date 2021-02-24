// Jenni
using UnityEngine;

public class EventManager : MonoBehaviour {
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

    #region Events and Delegates
    public delegate void OnAppStartHandler();
    public event OnAppStartHandler OnAppStart;

    public delegate void OnAppExitHandler();
    public event OnAppExitHandler OnAppExit;

    #endregion

    #region Class Methods

    public void BroadcastAppStart() {
        OnAppStart?.Invoke();
    }

    public void BroadcastAppExit() {
        OnAppExit?.Invoke();
    }

    #endregion
}