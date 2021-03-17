using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToDodgeCoin : MonoBehaviour {

    public void ChangeToDodgeCoin() {
        SceneManager.LoadScene("dodgecoin_ui", LoadSceneMode.Single);
    }
}