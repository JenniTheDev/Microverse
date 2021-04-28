// Jenni
using SOEvents.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Managers/GameManager")]
public class GameManager : ScriptableObject {
    [SerializeField] private GameState currentState = GameState.None;
    [SerializeField] private GameEventGameState onGameStateChange;

    public GameState CurrentState {
        get { return this.currentState; }
        private set {
            this.currentState = value;
            onGameStateChange.Raise(this.currentState);
        }
    }

    #region Methods

    public void PlayGame() {
        currentState = GameState.Playing;
    }

    public void EndGame() {
        currentState = GameState.GameOver;
    }

    #endregion Methods
}