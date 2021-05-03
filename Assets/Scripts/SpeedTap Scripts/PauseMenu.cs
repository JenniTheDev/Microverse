using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI, currentGame;

    void Start()
    {
        if(GameIsPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        currentGame.SetActive(false);
       // highscoreUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true; 
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        currentGame.SetActive(true);
        //highscoreUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false; 
    }


    /* ---------------- Highscore screen ---------------- *//*

    public void HighscoreScreen()
    {
        highscoreUI.SetActive(true);
        pauseMenuUI.SetActive(true);
        currentGame.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = false;
    }
  */
}
