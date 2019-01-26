﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public float TimeUntilDeactivation;
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForDeactivation()
    {
        yield return new WaitForSeconds(TimeUntilDeactivation);
        GetComponent<Collider2D>().enabled = false;
    }


}
