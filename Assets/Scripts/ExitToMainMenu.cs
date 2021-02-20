// Jenni
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitToMainMenu : MonoBehaviour
{
public void ToMainMenu() {
        SceneManager.LoadScene("Main Menu Production", LoadSceneMode.Single);

    }
    
}
