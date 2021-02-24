using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static System.Random;


/*
 * Testing working reaction button and results dispay 
 */

public class STReactionGamePlay : MonoBehaviour
{
    public Stopwatch timer = new Stopwatch();
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

   
}






    

