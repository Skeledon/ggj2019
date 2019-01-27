using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int Value { get; private set; }
    public int MaxValue = 100;
    public int EatValue;
    public float InvulnerabilityFrame;
    public float FlashingFrame;
    public SpriteRenderer myRenderer;
    public GameObject ObjectToDestroy;
    public float InitialInvulnerability;
    public AudioClip Hit;
    public AudioClip Heal;
    public AudioSource myAudioSource;

    private bool immortal = false;
    private bool Flashing = false;

    private void Start()
    {
        Value = MaxValue;
        StartCoroutine(WaitForInvulnerability(InitialInvulnerability));
    }
    public int Modify(int val)
    {
        return Modify(val, false);

    }

    public int Modify(int val, bool ignoreInvulnerability)
    {
        if (!immortal || ignoreInvulnerability)
        {
            Value += val;

            Value = Mathf.Clamp(Value, 0, MaxValue);
            if (Value == 0)
            {
                if (!ObjectToDestroy)
                    Destroy(gameObject);
                else
                    Destroy(ObjectToDestroy);
                return EatValue;
            }
            if (!ignoreInvulnerability)
            {
                if (val < 0)
                    myAudioSource.PlayOneShot(Hit);
                else
                    myAudioSource.PlayOneShot(Heal);
                StartCoroutine(WaitForInvulnerability(InvulnerabilityFrame));
                StartCoroutine(WaitForEndFlash());
            }

        }
        return 0;
    }

    public void SetImmortal(bool val)
    {
        immortal = val;
    }

    IEnumerator WaitForInvulnerability(float frame)
    {
        immortal = true;
        yield return new WaitForSeconds(frame);
        immortal = false;
    }
    IEnumerator WaitForEndFlash()
    {
        Flashing = true;
        StartCoroutine(Flash());
        yield return new WaitForSeconds(FlashingFrame);
        Flashing = false;
    }

    //Parametri Hardcoded per ordine
    IEnumerator Flash()
    {
        if(!myRenderer)
            myRenderer = GetComponent<SpriteRenderer>();
        float maxAlpha = .7f;
        float minAlpha = .2f;
        float currentAlpha = maxAlpha;
        float alphaStep = -3f;
        while(Flashing)
        {
            myRenderer.color += new Color(0, 0, 0, alphaStep * Time.deltaTime);
            if (myRenderer.color.a >= maxAlpha)
                alphaStep = -Mathf.Abs(alphaStep);
            if (myRenderer.color.a <= minAlpha)
                alphaStep = Mathf.Abs(alphaStep);
            yield return null;

        }
        myRenderer.color += new Color(0, 0, 0, 1);
    }
}
