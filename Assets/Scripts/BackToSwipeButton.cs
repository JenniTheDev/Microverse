using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToSwipeButton : MonoBehaviour {

    public void ToMainMenu() {
        SceneManager.LoadScene("Swipe Menu", LoadSceneMode.Single);
    }
}