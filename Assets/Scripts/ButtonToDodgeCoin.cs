using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToDodgeCoin : MonoBehaviour {

    public void ChangeToDodgeCoin() {
        SceneManager.LoadScene("dogebackground", LoadSceneMode.Single);
    }
}