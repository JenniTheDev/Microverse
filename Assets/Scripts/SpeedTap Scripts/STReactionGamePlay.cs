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
    public SpeedTapScoresLevel1 score;

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
            MovingTargetHit();

           /* if(PauseMenu.GameIsPaused)
            {
                //movingTarget.SetActive(false);
                
            }
            else
            {
                //movingTarget.SetActive(true);
                
            }*/
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
        Debug.Log(currentLevel.name);
         
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

    private void SaveHighScore(float value)
    {
        if (score.highScore1 < value)
        {
            // save score to json 
        }
        else if (score.highScore2 < value)
        {
            // save score to json
        }
        else if (score.highScore3 < value)
        {
            // save score to json
        }

        // if the value is not greater than highscore 3 then it should not be added 
    }

}