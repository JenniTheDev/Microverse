using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuDodgeCoin : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Button_menu"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }




}



