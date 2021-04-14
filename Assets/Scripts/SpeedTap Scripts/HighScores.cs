/*Casey Thatsanaphonh*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{

}

[System.Serializable]
public class SpeedTapScoresLevel1
{
    public string playerName;

    // Creating 3 separate variables because issues with declaring highScore as an array
    public float highScore1;
    public float highScore2;
    public float highScore3;
}