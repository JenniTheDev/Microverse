// Jenni
using UnityEngine;

public class StartGameplay : MonoBehaviour
{
    public void StartGame() {
        STEventManager.Instance.BroadcastGameStart();

    }


    
}
