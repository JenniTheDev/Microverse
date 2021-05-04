using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDotHighScoreTable : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");


        entryTemplate.gameObject.SetActive(false);

        //Load Scores from file
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Sort Entry by their fastest time
        highscores = SortHighscores(highscores);

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }


    }

    private Highscores SortHighscores(Highscores highscores)
    {
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score < highscores.highscoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        return highscores;
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 50f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;

        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;

        }


        entryTransform.Find("Num").GetComponent<Text>().text = rankString;

        float score = highscoreEntry.score;

        entryTransform.Find("Time").GetComponent<Text>().text = score.ToString();

       //string name = highscoreEntry.name;
       //entryTransform.Find("Name").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }


    public void AddHighscoreEntry(float score, string name)
    {
        // Create highscorenetry
        HighScoreEntry highscoreEntry = new HighScoreEntry { score = score, name = name };


        // Load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Add new entry to highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        //Save updated highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    
    private void FlushZeroes() // Function not used.
    {
        // Load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Delete all zero scores

        //Save updated

    }

    public void checkScore(float timergiven)
    {
        // Load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores = SortHighscores(highscores);

        if (highscores.highscoreEntryList.Count < 10) // If there are less than 10 entries
        {
            // We add the score anyway
            AddHighscoreEntry(timergiven, "AAA");
         
        }
        else // If there are 10 or more entries.
        {
            if (timergiven < highscores.highscoreEntryList[highscores.highscoreEntryList.Count - 1].score)
            {
                //We add the score
                AddHighscoreEntry(timergiven, "AAA");
                //We then delete the 11th entry
                highscores.highscoreEntryList.RemoveAt(10);
            }
            else
            {
                // We don't add the score.
            }
        }
    }

    private class Highscores
    {
        public List<HighScoreEntry> highscoreEntryList;
    }


    /*Represents a single high score entry*/
    [System.Serializable]
    private class HighScoreEntry
    {
        public float score;
        public string name;
    }

}
