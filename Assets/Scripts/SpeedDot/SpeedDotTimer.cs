using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDotTimer : MonoBehaviour
{
    private bool timerStarted = false; // this is used to determine when our timer is used. 
    public Text textobj;
    
    [SerializeField]
    public float timerRec = 0f;

    // Start is called before the first frame update
    void Start()
    {
        textobj.text = timerRec.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (timerStarted)
        {
            UpdateTimer();
            textobj.text = timerRec.ToString("00.0");
        }
        else
        {
            textobj.text = timerRec.ToString("00.0");
        }


    }

    public void StartTimer()
    {
        //TODO

        timerStarted = true;
    }


    public void StopTimer()
    {
        //todo
        timerStarted = false;
    }

    public void ResetTimer()
    {
        timerRec = 0f;
    }

    public void UpdateTimer()
    {
        timerRec += Time.deltaTime;
    }

    public float GetTime()
    {
        return timerRec;
    }


}
