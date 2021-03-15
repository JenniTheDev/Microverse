using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDraw : MonoBehaviour
{
    public LineRenderer Line;
    public float lineWidth = 0.04f;
    public float minimumVertexDistance = 0.1f;

    private bool isLineStarted;

    void Start()
    {
        // set the color of the line
        Line.startColor = Color.red;
        Line.endColor = Color.red;

        // set width of the renderer
        Line.startWidth = lineWidth;
        Line.endWidth = lineWidth;

        isLineStarted = false;
        Line.positionCount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Line.positionCount = 0;
            Vector3 mousePos = GetWorldCoordinate(Input.mousePosition);

            Line.positionCount = 2;
            Line.SetPosition(0, mousePos);
            Line.SetPosition(1, mousePos);
            isLineStarted = true;
        }

        if (Input.GetMouseButton(0) && isLineStarted)
        {
            Vector3 currentPos = GetWorldCoordinate(Input.mousePosition);
            float distance = Vector3.Distance(currentPos, Line.GetPosition(Line.positionCount - 1));
            if (distance > minimumVertexDistance)
            {
                Debug.Log(distance);
                UpdateLine();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isLineStarted = false;
        }
    }

    private void UpdateLine()
    {
        Line.positionCount++;
        Line.SetPosition(Line.positionCount - 1, GetWorldCoordinate(Input.mousePosition));
    }

    private Vector3 GetWorldCoordinate(Vector3 mousePosition)
    {
        Vector3 mousePos = new Vector3(mousePosition.x, mousePosition.y, 1);
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
