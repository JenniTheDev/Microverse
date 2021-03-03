using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDotDrawLine : MonoBehaviour
{
 
    public LineRenderer lr;
    private Touch theTouch;
    private float timeTouchEnded;
    private bool islineStarted;
    private Vector3 vectorHolder;
    public float lineWidth = .04f;
    

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
        theTouch = Input.GetTouch(0);

        if (theTouch.phase == TouchPhase.Began && islineStarted == false)
        {
            Vector3 touchPos = GetWorldCoordinate(theTouch.position);

            lr.SetPosition(0, touchPos); // Left off, http://gyanendushekhar.com/2020/04/05/draw-line-at-run-time-unity-3d/

        }
        else if(islineStarted == true && theTouch.phase == TouchPhase.Stationary)
        {

        }
        else if (theTouch.phase == TouchPhase.Ended && islineStarted == true)
        {

        }


    }

    private Vector3 GetWorldCoordinate(Vector3 touchPosition)
    {

        Vector3 touchPos = new Vector3(touchPosition.x, touchPosition.y, 1);
        return Camera.main.ScreenToWorldPoint(touchPos);
    }
}
