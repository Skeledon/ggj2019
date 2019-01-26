using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    public bool Invert = false;
    SpriteRenderer myRenderer;

    Vector3 baseScale;
    float oldX;
    // Start is called before the first frame update
    void Start()
    {
        oldX = transform.position.x;
        baseScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldX < transform.position.x)
        {
            transform.localScale = new Vector3(baseScale.x, baseScale.y, baseScale.z);
            if(Invert)
                transform.localScale = new Vector3(-baseScale.x, baseScale.y, baseScale.z);
        }
        if (oldX > transform.position.x)
        {
            transform.localScale = new Vector3(-baseScale.x, baseScale.y, baseScale.z);
            if (Invert)
                transform.localScale = new Vector3(baseScale.x, baseScale.y, baseScale.z);
        }
        oldX = transform.position.x;
    }
}
