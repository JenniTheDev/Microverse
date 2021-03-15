using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDotDrawLine : MonoBehaviour
{
 
    public LineRenderer lr;
    private Touch theTouch;
    private float timeTouchEnded;

    private Vector3 vectorHolder;
    public float lineWidth = .04f;

    private bool islineStarted;


    // Start is called before the first frame update
    void Start()
    {
        lr.startColor = Color.red;
        lr.endColor = Color.red;

        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;

        islineStarted = false;
        lr.positionCount = 2;

    }

    // Update is called once per frame
    void Update()
    {
        theTouch = Input.GetTouch(0); // we get the touch info of the index finger

        if (theTouch.phase == TouchPhase.Began && islineStarted == false) //if the line is started and the touch is begun
        {
            Vector3 touchPos = GetWorldCoordinate(theTouch.position); //getting touch info
            Debug.Log("Touch Pos World coordinate: " + touchPos);
            lr.positionCount = 2;
            lr.SetPosition(0, touchPos); // Left off, http://gyanendushekhar.com/2020/04/05/draw-line-at-run-time-unity-3d/ //render the beginning of the line
            lr.SetPosition(1, touchPos);
        }
        else if(theTouch.phase == TouchPhase.Stationary && islineStarted == true) // if touch is still but line is already started
        {
            Vector3 touchPos = GetWorldCoordinate(theTouch.position);

            lr.SetPosition(1, touchPos);
        }
        else if (theTouch.phase == TouchPhase.Ended && islineStarted == true) // If line is started and touch is lifted, then we delete the line
        {

        }
         

    }

    private Vector3 GetWorldCoordinate(Vector3 touchPosition)
    {

        Vector3 touchPos = new Vector3(touchPosition.x, touchPosition.y, 0);
        Debug.Log("Touch Pos RAw: " + touchPos);
        return Camera.main.ScreenToWorldPoint(touchPos);
    }
}
