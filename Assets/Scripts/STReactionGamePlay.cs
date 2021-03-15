/*Casey Thatsanaphonh*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Testing working reaction button and results dispay 
 */

/* TODO
 * Utilize event manager instead of onClicked function. Optimize timer, avoid using the system.diagnostics 
 * 
 * Optimized timer functions and able to get accurate time calculated - Casey 
 * 
 * 
 * TODO: 
 */
public class STReactionGamePlay : MonoBehaviour
{
    [SerializeField] private Text readyText, resultText; 
    [SerializeField] private SpriteRenderer background;
    [SerializeField] Button startStopButton;
    [SerializeField] Camera mainCameraInScene; 
    private float reactionTime, startTime, randomDelayBeforeMeasuring;
    private bool clockIsTicking, timerCanBeStopped;
    public Text fastestTime;
    

    // Start is called before the first frame update
    void Start()
    {
        InitializeVar();
        startStopButton.onClick.AddListener(WhenButtonisClicked);

        fastestTime.text = PlayerPrefs.GetFloat("FastestTime", 0.0f).ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
        MovingTargetHit();
        
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
                /*
                 * TODO: 
                 * update this to have a button control the restart function 
                 */
                clockIsTicking = false;     

            }
            else if (clockIsTicking && !timerCanBeStopped)
            {
                StopCoroutine(nameof(StartMeasuring));
                reactionTime = 0f;
                /*
                * TODO: 
                * update this to have a button control the restart function 
                */
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

}




/*
 *  public Stopwatch timer = new Stopwatch();
    private float timeLeft;
    public bool clicked;
    public Image bgColor; 

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomNumber();
        clicked = false;
        ChangeBGRed();
    }

    // Update is called once per frame
    void Update()
    {
        // when 0 the timer will start 
        Countdown();

       
        
    }

    private static float GenerateRandomNumber()
    {
        System.Random rng = new System.Random();
        float rand = (float)rng.Next(5, 6);
        return rand;

    }
    
    public void UpdateReactionTime()
    {
       
        TimeSpan timepass = timer.Elapsed;
        string timeString = String.Format("{000}" + "  MS", timepass.Milliseconds);

        Text reactionTime = GameObject.Find("ResultsText").GetComponent<Text>();
        reactionTime.text = timeString;

        timer.Stop();
        UnityEngine.Debug.Log(timepass);
    }
   
    private void Countdown()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            timer.Start();
            ChangeBGGreen();

        }
    }

    public void ButtonClicked()
    {
        clicked = true;
        timer.Stop();
    }

    public void ChangeBGRed()
    {
        bgColor.GetComponent<Image>().color = Color.red; 
    }

    public void ChangeBGGreen()
    {
        bgColor.GetComponent<Image>().color = Color.green;
    }

    private void StartGame()
    {
        
    }

    private void Subscribe()
    {
        Unsubscribe();
        STEventManager.Instance.OnGameStart += StartGame;
    }

    private void Unsubscribe()
    {
        STEventManager.Instance.OnGameStart -= StartGame;
    }
 * 
 * 
 */



