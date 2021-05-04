using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuDodgeCoin : MonoBehaviour
{
    //Pause menu variables
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public bool isPaused = false;


    //Timer variables//
    /*Reference https://www.youtube.com/watch?v=x-C95TuQtf0 */
    public Text timerText;
    public Text timeSurvivedText;

    public float startTime;

    public string minutes;
    public string seconds;

    public string pausedMinutes;
    public string pausedSeconds;
    public string survivedMinutes;
    public string survivedSeconds;

    public float t;
    
    //gets starting time
    void Start()
    {
        isPaused = false;
        startTime = Time.time;
    }

    //Updates time when running
    void Update()
    {
        //If paused display paused time else display running time
        if (isPaused) 
        {
            //place holder block of code until a dead/game over state is implemented. 
            //time survived will be paused time
            survivedMinutes = minutes;
            survivedSeconds = seconds;
            //timeSurvivedText.text = "You have survived "+ survivedMinutes + ":" + survivedSeconds;
            

            //

            pausedMinutes = minutes;
            pausedSeconds = seconds;
            timerText.text = pausedMinutes + ":" + pausedSeconds;
        }
        else
        {
            t = Time.time - startTime;
            
            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2"); //only prints two leading digits
            //timerText.text = minutes + ":" + seconds;
            //timeSurvivedText.text = "You have survived " + minutes + " minutes & " + seconds + " seconds!";
        }
    }





    //resumes the game
    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
      
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    //pauses the game
    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
    
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    //quits the game
    public void Quit()
    {
        Application.Quit();
    }
}
