using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class STLevelChange : MonoBehaviour
{
    private string lvl1 = "SpeedTapLevel1", lvl2 = "SpeedTapLevel2"; 
    public void NextLevel()
    {
        SceneManager.LoadScene(lvl2, LoadSceneMode.Single);
    }

    public void PrevLevel()
    {
        SceneManager.LoadScene(lvl1, LoadSceneMode.Single);
    }
}
