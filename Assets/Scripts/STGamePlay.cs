// Jenni
using System.Collections;
using UnityEngine;



public class STGamePlay : MonoBehaviour {
    [SerializeField] private Text gameText;
    [SerializeField] private SpriteRenderer Background;
    private float reactionTime, startTime, randomDelayBeforeMeasuring;
    private bool clockIsTicking, timerCanBeStopped;
    private Touch touch;

    private void Start() {
        Subscribe();
        // Not sure if this should be here or somewhere else
        
    }

    private void Update() {
       // if (touch.phase == TouchPhase.Began) { // this may need to be changed
       // If current state is playing ?
            if (!clockIsTicking) {
                StartCoroutine("StartMeasuring");
                gameText.text = "Wait for Green";
                Background.color = Color.red;
                clockIsTicking = true;
                timerCanBeStopped = false;
            } else if (clockIsTicking && timerCanBeStopped) {
                StopCoroutine("StartMeasuring");
                reactionTime = Time.time - startTime;
                gameText.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n";
                clockIsTicking = false;
                STEventManager.Instance.BroadcastGameOver();
            } else if (clockIsTicking && !timerCanBeStopped) {
                StopCoroutine("StartMeasuring");
                reactionTime = 0f;
                clockIsTicking = false;
                timerCanBeStopped = true;
                gameText.text = "Too Early\n";
                STEventManager.Instance.BroadcastGameOver();
            }
        }
   // }

    private void StartGame() {
        reactionTime = 0f;
        startTime = 0f;
        randomDelayBeforeMeasuring = 0f;
        gameText.text = "Tap to Start";
        clockIsTicking = false;
        timerCanBeStopped = true;
    }

    private IEnumerator StartMeasuring() {
        randomDelayBeforeMeasuring = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomDelayBeforeMeasuring);
        Background.color = Color.green;
        startTime = Time.time;
        clockIsTicking = true;
        timerCanBeStopped = true;
    }

    private void Subscribe() {
        Unsubscribe();
        STEventManager.Instance.OnGameStart += StartGame;
    }

    private void Unsubscribe() {
        STEventManager.Instance.OnGameStart -= StartGame;
    }
}