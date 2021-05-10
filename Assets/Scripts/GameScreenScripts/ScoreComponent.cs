using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreChangedArgs : EventArgs
{
    public float NewValue { get; private set; }

    public ScoreChangedArgs(float newValue) => NewValue = newValue;
}
public class ScoreComponent : MonoBehaviour
{
    public event EventHandler<ScoreChangedArgs> OnScoreChanged;
    private float score;
    float completedScore = 400;
    float MEDIUM_SCORE = 700;
    float HARD_SCORE = 1000;

    public void AdjustDifficulty()
    {
        if (KeepOverTimeComponent.difficulty == 2)
        {
            completedScore = MEDIUM_SCORE;

        }
        if (KeepOverTimeComponent.difficulty == 3)
        {
            completedScore = HARD_SCORE;
        }
    }
    private void Start()
    {
        AdjustDifficulty();
    }
    public void AddScore(float value)
    {
        score += value;
        OnScoreChanged?.Invoke(this, new ScoreChangedArgs(score));
        if(score == completedScore)
        {
            KeepOverTimeComponent.GalagaRéussi = true;
            SceneManager.LoadScene("FinalScene");
        }
    }
    public float GetScore() => score;
}
