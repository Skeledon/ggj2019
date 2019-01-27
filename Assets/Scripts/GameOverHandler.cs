using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public GameObject GameOverScreen;
    public ScoreHandler MyScore;
    public AudioClip GameOverAudio;
    public AudioSource MySource;

    private void OnDestroy()
    {
        if (!MyScore.GameEnded)
        {
            GameOverScreen.SetActive(true);
            MySource.clip = GameOverAudio;
            MySource.Play();
        }
    }
}
