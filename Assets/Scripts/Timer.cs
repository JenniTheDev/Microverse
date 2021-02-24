using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*********************************************************************************
 * This scrips takes care of the count down timer that tells the player how long *
 * they must survive.                                                            *
 *********************************************************************************/
public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 60;
    public bool takingAway = false;

    
    //on start executes the clock
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "" + secondsLeft;
    }

    //only takes away time when greater than 0
    void Update()
    {
        if(takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }


    //takes a way times each second and displays onto the screen
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        takingAway = false;
    }
}
