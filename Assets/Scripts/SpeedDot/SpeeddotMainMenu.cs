using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeeddotMainMenu : MonoBehaviour
{
    public GameObject SpeedDotConnector2D;
    public GameObject SpeedDots;
    public GameObject GamePlay;
    
    /*-----------------------*/
    public GameObject Timer;
    private SpeedDotTimer SDTimer;
    /*-----------------------*/

    public GameObject MainMenuCanvas;
    
    /*------------------------------*/
    public GameObject HighScoreTable;
    private SpeedDotHighScoreTable SDHSTable;
    /*------------------------------*/

    public GameObject GoToSwipeMenu;

    // Start is called before the first frame update
    void Start()
    {
        SDHSTable = HighScoreTable.GetComponent<SpeedDotHighScoreTable>();

        SpeedDotConnector2D.SetActive(false);
        SpeedDots.SetActive(false);
        GamePlay.SetActive(false);
        Timer.SetActive(false);
        MainMenuCanvas.SetActive(true);
        HighScoreTable.SetActive(false);
        GoToSwipeMenu.SetActive(true);

        
        SDHSTable.HighScoreTableCheck();
        

        //Check if we have a highscore table


    }

    // Update is called once per frame
    void Update()
    {


    }

    public void StartGame()
    {
        //Debug.Log("Populate");
        SpeedDotConnector2D.SetActive(true);
        SpeedDots.SetActive(true);
        
        GamePlay.SetActive(true);

        Timer.SetActive(true);
        MainMenuCanvas.SetActive(false);
        GoToSwipeMenu.SetActive(false);
    }

    public void ReturnToMain()
    {
        SpeedDotConnector2D.SetActive(false);
        SpeedDots.SetActive(false);
        GamePlay.SetActive(false);
        Timer.SetActive(false);
        HighScoreTable.SetActive(false);
        GoToSwipeMenu.SetActive(true);
        MainMenuCanvas.SetActive(true);
        

    }

    public void EndGametoHighScore()
    {
        SDTimer = Timer.GetComponent<SpeedDotTimer>();
        SDHSTable = HighScoreTable.GetComponent<SpeedDotHighScoreTable>();

        SDTimer.StopTimer();
        
        SDHSTable.checkScore(SDTimer.GetTime()); // Ignore AAA, originally for name input, not doing that no more.
        SDTimer.ResetTimer();

        /*--------Turn off stuff we don't need, then render table-----*/
        SpeedDotConnector2D.SetActive(false);
        SpeedDots.SetActive(false);
        GamePlay.SetActive(false);
        Timer.SetActive(false);
        HighScoreTable.SetActive(true);
    }
}


