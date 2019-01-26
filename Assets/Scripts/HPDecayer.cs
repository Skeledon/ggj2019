using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDecayer : MonoBehaviour
{
    public float TimeBetweenDecays;
    public int DecayAmount;
    private HP hpToDecay;
    // Start is called before the first frame update
    void Start()
    {
        hpToDecay = GetComponent<HP>();
        StartCoroutine(WaitForDecay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitForDecay()
    {
        yield return new WaitForSeconds(TimeBetweenDecays);
        hpToDecay.Modify(DecayAmount, true);

        StartCoroutine(WaitForDecay());
    }
}
