using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsBeating : MonoBehaviour
{
    public float AnimationDuration;
    public float MinBeatInterval;
    public float MaxBeatInterval;

    public float ScaleBeat;

    public HP HpLink;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Beat());
    }


    IEnumerator Beat()
    {
        float currentBeat = (-(MaxBeatInterval - MinBeatInterval) / 100) * HpLink.Value + MaxBeatInterval;
        transform.localScale += Vector3.one * ScaleBeat;
        yield return new WaitForSeconds(AnimationDuration);
        transform.localScale -= Vector3.one * ScaleBeat;
        yield return new WaitForSeconds(currentBeat - AnimationDuration);
        StartCoroutine(Beat());
    }
}
