using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownHandler : MonoBehaviour
{
    public float StartTime;
    public Text MyText;
    public AudioSource mySource;

    private float CurrentTime;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        CurrentTime = StartTime;
    }

    // Update is called once per frame
    void Update()
    {

        CurrentTime -= Time.unscaledDeltaTime;
        if(CurrentTime > .5)
        {
            MyText.text = CurrentTime.ToString("F0");
        }

        if(CurrentTime <= -1)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            mySource.Play();
        }
        if (CurrentTime <= 0)
        {
            MyText.text = "Paguri!";
        }

    }
}
