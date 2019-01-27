using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    public float MaxTime;
    public float CurrentTime;
    public Text TimerUI;
    public GameObject Paguro;
    public GameObject WinScreen;
    public ScoreHandler myScore;

    private void Start()
    {
        CurrentTime = MaxTime;
    }
    // Update is called once per frame
    void Update()
    {
        TimerUI.text = CurrentTime.ToString("F0");
        CurrentTime -= Time.deltaTime;
        CurrentTime = Mathf.Clamp(CurrentTime, 0, Mathf.Infinity);
        if(CurrentTime <= 0 && !myScore.GameEnded)
        {
            WinScreen.SetActive(true);
            Paguro.GetComponent<HP>().SetImmortal(true);
        }
    }
}
