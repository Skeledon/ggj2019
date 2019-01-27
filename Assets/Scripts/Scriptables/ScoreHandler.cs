using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreHandler : ScriptableObject
{
    public int Score;

    public void AddScore(int score)
    {
        Score += score;
    }

    public void Reset()
    {
        Score = 0;
    }
}
