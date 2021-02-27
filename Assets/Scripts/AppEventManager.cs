// Jenni
using UnityEngine;

[CreateAssetMenu(menuName = "Appwide Event Manager")]
public class AppEventManager : ScriptableObject {

    #region Singleton
    private static bool isQuitting = false;
    private static AppEventManager instance = null;

    public static AppEventManager Instance {
        get {
            if (instance == null && !isQuitting) {
                instance = new AppEventManager();
                Application.quitting += () => isQuitting = true;
            }
            return instance;
        }
    }

    private AppEventManager() {
    }

    #endregion Singleton

    #region Events and Delegates
    public delegate void OnAppStartHandler();
    public event OnAppStartHandler OnAppStart;

    public delegate void OnAppExitHandler();
    public event OnAppExitHandler OnAppExit;

    #endregion

    #region Class Methods

    private void Awake() {
        
    }

    private void OnEnable() {
        
    }

    private void OnDisable() {
        
    }

    private void OnDestroy() {
        
    }

    public void BroadcastAppStart() {
        OnAppStart?.Invoke();
    }

    public void BroadcastAppExit() {
        OnAppExit?.Invoke();
    }

    #endregion




}