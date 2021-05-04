/*Casey Thatsanaphonh*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 





public class STReactionGamePlay : MonoBehaviour
{
    [SerializeField] private Text readyText, resultText; 
    [SerializeField] private SpriteRenderer background;
    [SerializeField] Button startStopButton;
    [SerializeField] Camera mainCameraInScene; 
    private float reactionTime, startTime, randomDelayBeforeMeasuring;
    private bool clockIsTicking, timerCanBeStopped;
    private Scene currentLevel; 
    public Text fastestTime;
    public SpeedTapScoresLevel1 score = new SpeedTapScoresLevel1();

    private const string lvl1 = "SpeedTapLevel1", lvl2 = "SpeedTapLevel2";


    // Start is called before the first frame update
    void Start()
    {
        InitializeVar();

        
        // run this line if lvl 1 
        if (currentLevel.name == lvl1)
        {
            startStopButton.onClick.AddListener(WhenButtonisClicked);
 
        }
        
       
       
        // fastestTime.text = PlayerPrefs.GetFloat("FastestTime", 0.0f).ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
        // run function if lvl 2
        if (currentLevel.name == lvl2)
        {
            // sets obj to inactive when game is paused 
            if (!PauseMenu.GameIsPaused)
            {
                MovingTargetHit();
            }
            

        }
        
    }

    private void MovingTargetHit()
    {
        // click being detected 
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = mainCameraInScene.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousepos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousepos2D, Vector2.zero);


            // this if statement is not working 
            if (hit.collider != null)
            {
                WhenButtonisClicked();
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
            }
        }
    }
    // Initialize variables at start
    private void InitializeVar()
    {
        reactionTime = 0f;
        startTime = 0f;
        randomDelayBeforeMeasuring = 0f;
        readyText.text = "Click button to Start";
        resultText.text = "";
        clockIsTicking = false;
        timerCanBeStopped = true;

        currentLevel = SceneManager.GetActiveScene();
         
    }

    public void WhenButtonisClicked()
    {
        
            if (!clockIsTicking)
            {
                StartCoroutine(nameof(StartMeasuring));
                readyText.text = "Wait for Green";
                resultText.text = "";
                background.color = Color.red;
                clockIsTicking = true;
                timerCanBeStopped = false;
            }
            else if (clockIsTicking && timerCanBeStopped)
            {
                StopCoroutine(nameof(StartMeasuring));
                reactionTime = Time.time - startTime;
                resultText.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n" + "Click button to start again";

                // Compare scores for save 
                SaveHighScore(reactionTime);
                Debug.Log(reactionTime);

            clockIsTicking = false;     

            }
            else if (clockIsTicking && !timerCanBeStopped)
            {
                StopCoroutine(nameof(StartMeasuring));
                reactionTime = 0f;
              
            clockIsTicking = false;
                timerCanBeStopped = true;
                resultText.text = "Too early\n" + "Click Button to start again";
                

            }
        
        
    }

    private IEnumerator StartMeasuring()
    {
        // will wait for delay before starting 
        randomDelayBeforeMeasuring = Random.Range(0.5f, 3f);
        yield return new WaitForSeconds(randomDelayBeforeMeasuring);
        background.color = Color.green;
        startTime = Time.time;
        clockIsTicking = true;
        timerCanBeStopped = true;
    }


    /*------------ Save and Load Functions ------------*/
    private void SaveHighScore(float value)
    {
        /* Loading save data to object, if does not exist default values will be zero */
        score = SaveManager.Load();


        if (score.highScore1 > value || score.highScore1 == 0f)
        {
            // moving highscore values down and setting new high score 
            score.highScore3 = score.highScore2;
            score.highScore2 = score.highScore1;
            score.highScore1 = value;

            // save updated scores to the save file 
            SaveManager.Save(score);
            Debug.Log(score.highScore1);

        }
        else if (score.highScore2 > value || score.highScore2 == 0f)
        {
            // moving highscore values down and setting new high score 
            score.highScore3 = score.highScore2;
            score.highScore2 = value;

            // save updated scores to the save file 
            SaveManager.Save(score);
            Debug.Log(score.highScore2);
        }
        else if (score.highScore3 > value)
        {
            // moving highscore values down and setting new high score 
            score.highScore3 = value;

            // save updated scores to the save file 
            SaveManager.Save(score);
            Debug.Log(score.highScore3);
        }

        
        // if the value is not greater than highscore 3 then it should not be added 
    }

}