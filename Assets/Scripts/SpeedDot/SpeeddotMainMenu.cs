using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeeddotMainMenu : MonoBehaviour
{
    public GameObject connectorfor2D;
    public GameObject speeddots;
    public GameObject gameplay;
    
    /*-----------------------*/
    public GameObject timerobj;
    private SpeedDotTimer SDTimer;
    /*-----------------------*/

    public GameObject mainmenucanvas;
    
    /*------------------------------*/
    public GameObject highscoretable;
    private SpeedDotHighScoreTable SDHSTable;
    /*------------------------------*/

    // Start is called before the first frame update
    void Start()
    {
        connectorfor2D.SetActive(false);
        speeddots.SetActive(false);
        gameplay.SetActive(false);
        timerobj.SetActive(false);
        mainmenucanvas.SetActive(true);
        highscoretable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void StartGame()
    {
        Debug.Log("Populate");
        connectorfor2D.SetActive(true);
        speeddots.SetActive(true);
        
        gameplay.SetActive(true);

        timerobj.SetActive(true);
        mainmenucanvas.SetActive(false);
    }

    public void ReturnToMain()
    {
        connectorfor2D.SetActive(false);
        speeddots.SetActive(false);
        gameplay.SetActive(false);
        timerobj.SetActive(false);
        highscoretable.SetActive(false);
        mainmenucanvas.SetActive(true);
       
    }

    public void EndGametoHighScore()
    {
        SDTimer = timerobj.GetComponent<SpeedDotTimer>();
        SDHSTable = highscoretable.GetComponent<SpeedDotHighScoreTable>();

        SDTimer.StopTimer();
        SDHSTable.AddHighscoreEntry(SDTimer.GetTime(), "AAA"); // Ignore AAA, originally for name input, not doing that no more.
        SDTimer.ResetTimer();

        /*--------Turn off stuff we don't need, then render table-----*/
        connectorfor2D.SetActive(false);
        speeddots.SetActive(false);
        gameplay.SetActive(false);
        timerobj.SetActive(false);
        highscoretable.SetActive(true);
    }
}


