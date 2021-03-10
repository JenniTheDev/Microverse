using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToSpeedTap : MonoBehaviour {

    public void ChangeToSpeedTap() {
        SceneManager.LoadScene("SpeedTap - Casey", LoadSceneMode.Single);
    }
}