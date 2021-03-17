using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToSpeedDot : MonoBehaviour {

    public void ChangeToSpeedDot() {
        SceneManager.LoadScene("SpeedDotGame1", LoadSceneMode.Single);
    }
}