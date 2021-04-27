// Jenni
using UnityEngine;
using Variables;
using TMPro;
using UnityEngine.UI;

public class JSScore : MonoBehaviour {
    [SerializeField] private IntVariable score;
    [SerializeField] private TMP_Text scoreText;
    private int scoreTemp;

    private void Update() {
        scoreTemp = score.GetValue();
        scoreText.text = "Level " + scoreTemp.ToString();
    }
}