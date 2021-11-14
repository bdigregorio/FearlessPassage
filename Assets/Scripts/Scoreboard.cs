using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour {
    int score;
    TMP_Text scoreText;

    private void Start() {
        scoreText = GetComponent<TMP_Text>();
    }

    public void IncreaseScore(int points) {
        score += points;
        scoreText.text = $"Score: {score}";
    }
}
