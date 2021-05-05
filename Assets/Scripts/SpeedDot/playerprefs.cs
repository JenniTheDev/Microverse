using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerprefs : MonoBehaviour
{
    // Start is called before the first frame update

    public void DeleteAll()
    {
        PlayerPrefs.DeleteKey("highscoreTable");
        Debug.Log("Lmao Deleted");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
