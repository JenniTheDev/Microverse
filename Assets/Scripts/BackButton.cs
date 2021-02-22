using UnityEngine.SceneManagement;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void ToMainMenu() {
        
        SceneManager.LoadScene("Main Menu Production", LoadSceneMode.Single);
    }
}
