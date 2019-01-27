using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
    public Text myText;
    public ScoreHandler myScore;

    private void OnEnable()
    {
        myText.text = "Score: " + myScore.Score;
    }

}
