using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuDodgeCoin : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

  

    // Update is called once per frame
    void Start()
    {
        
    }

    //resumes the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    //pauses the game
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    //quits the game
    public void Quit()
    {
        Application.Quit();
    }




}



