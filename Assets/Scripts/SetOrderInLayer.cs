using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOrderInLayer : MonoBehaviour
{
    SpriteRenderer[] myRenderers;
    // Start is called before the first frame update
    void Start()
    {
        int order = Random.Range(-2000, 2000);
        myRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer s in myRenderers)
        {
            s.sortingOrder = order;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
