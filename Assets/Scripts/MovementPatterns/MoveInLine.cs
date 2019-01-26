using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInLine : GenericMovement
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Speed * Time.deltaTime, Space.World);
    }

    public override void StartMoving(Vector2 direction)
    {
        dir = direction;
    }
}
