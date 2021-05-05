using System;
using UnityEngine;

public class ScoreChangedArgs : EventArgs
{
    public float NewValue { get; private set; }

    public ScoreChangedArgs(float newValue) => NewValue = newValue;
}
public class ScoreComponent : MonoBehaviour
{
    public event EventHandler<ScoreChangedArgs> OnScoreChanged;
    private float score;

    public void AddScore(float value)
    {
        score += value;
        OnScoreChanged?.Invoke(this, new ScoreChangedArgs(score));
    }
    public float GetScore() => score;
}
