using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericMovement : MonoBehaviour
{
    public float Speed;

    protected Vector2 dir = Vector2.zero;
    public abstract void StartMoving(Vector2 direction);
   
}
