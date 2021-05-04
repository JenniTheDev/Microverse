
using TMPro;
using UnityEngine;
using Variables;

public class CoinsSurvivedScore : MonoBehaviour
{
    [SerializeField] private IntVariable score;
    [SerializeField] private TMP_Text scoreText;

    private void Update() {
        scoreText.text = $"Coins Survived: {score.IntValue.ToString()}";
    }
}
