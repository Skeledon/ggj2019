using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreHandler : ScriptableObject
{
    public int Score;

    public bool GameEnded = false;

    public void AddScore(int score)
    {
        if(!GameEnded)
            Score += score;
    }

    public void Reset()
    {
        Score = 0;
        GameEnded = false;
    }

    public void GameEnding()
    {
        GameEnded = true;
    }
}
