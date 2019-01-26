using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int Value { get; private set; }
    public int MaxValue = 100;
    public float InvulnerabilityFrame;

    private bool immortal = false;

    private void Start()
    {
        Value = MaxValue;
    }
    public void Modify(int val)
    {
        Value += val;
        Value = Mathf.Clamp(Value, 0, MaxValue);
        Debug.Log(Value);
        if (Value == 0)
            Destroy(gameObject);
        StartCoroutine(WaitForInvulnerability());

    }

    IEnumerator WaitForInvulnerability()
    {
        immortal = true;
        yield return new WaitForSeconds(InvulnerabilityFrame);
        immortal = false;
    }
}
