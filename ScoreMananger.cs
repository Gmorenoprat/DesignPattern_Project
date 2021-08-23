using UnityEngine;
using System;

public class ScoreMananger : MonoBehaviour
{
    public int score { get; set; }

    public event Action<string> actualizarScore;

    public static ScoreMananger Instance
    {
        get { return _instance; }
    }

    static ScoreMananger _instance;

    public void Start()
    {
        _instance = this;

        ResetScore();
        actualizarScore += UIMananger.Instance.ActualizarScore;

    }
    public void ResetScore()
    {
        score = 0;
    }

    public void SumarScore(int points)
    {
        score += points;
        actualizarScore(score.ToString());
    }


}
