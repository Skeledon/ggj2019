using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int Value { get; private set; }
    public int MaxValue = 100;
    public int EatValue;
    public float InvulnerabilityFrame;
    public SpriteRenderer myRenderer;
    public GameObject ObjectToDestroy;

    private bool immortal = false;

    private void Start()
    {
        Value = MaxValue;
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
            if(!ignoreInvulnerability)
                StartCoroutine(WaitForInvulnerability());

        }
        return 0;
    }

    IEnumerator WaitForInvulnerability()
    {
        immortal = true;
        StartCoroutine(Flash());
        yield return new WaitForSeconds(InvulnerabilityFrame);
        immortal = false;
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
        while(immortal)
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
