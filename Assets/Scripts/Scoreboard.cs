using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour {
    private int score;

    public void IncreaseScore(int points) {
        score += points;
        Debug.Log($"Score increased by {points} points; Score is now {score}");
    }
}
