using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreLabel;
    public int score = 0;
    void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreLabel.text = $"Score: {score}";
    }

    public int GetScore()
    {
        return score;
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScore();
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        UpdateScore();
    }
}
