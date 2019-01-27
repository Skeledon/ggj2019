using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaPattern : GenericMovement
{
    public float DistanceToActivate;
    public int AngleOfAttack;
    Transform player;
    Transform t;
    float targetPosition;
    float oldY;

    private int currentState = 0; //0 = start, 1= first angle, 2= parallel, 3= second angle, 4= last

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        catch(System.Exception e)
        { }
        t = transform;
        oldY = t.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Speed * Time.deltaTime, Space.World);
        if (player)
        {
            if (currentState == 0)
            {
                if (Mathf.Abs(t.position.x - player.position.x) < DistanceToActivate)
                {
                    if (player.position.y > t.position.y)
                    {
                        float a = AngleOfAttack * Mathf.Deg2Rad * Mathf.Sign(dir.x) + Vector2.Angle(Vector2.right, dir) * Mathf.Deg2Rad;
                        dir = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
                    }
                    else
                    {
                        float a = AngleOfAttack * Mathf.Deg2Rad * -Mathf.Sign(dir.x) + Vector2.Angle(Vector2.right, dir) * Mathf.Deg2Rad;
                        dir = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
                    }
                    targetPosition = player.position.y;
                    currentState = 1;
                }
            }
            if (currentState == 1 || currentState == 3)
            {
                if (Mathf.Abs(t.position.y - targetPosition) <= .3f)
                {
                    dir = Vector2.right * Mathf.Sign(dir.x);
                    currentState++;
                    currentState = Mathf.Clamp(currentState, 0, 4);

                }
            }
            if (currentState == 2)
            {
                if (Mathf.Abs(t.position.x - player.position.x) > DistanceToActivate)
                {
                    if (oldY > t.position.y)
                    {
                        float a = AngleOfAttack * Mathf.Deg2Rad * Mathf.Sign(dir.x) + Vector2.Angle(Vector2.right, dir) * Mathf.Deg2Rad;
                        dir = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
                    }
                    else
                    {
                        float a = AngleOfAttack * Mathf.Deg2Rad * -Mathf.Sign(dir.x) + Vector2.Angle(Vector2.right, dir) * Mathf.Deg2Rad;
                        dir = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
                    }
                    targetPosition = oldY;
                    currentState = 3;
                }
            }
        }
    }

    public override void StartMoving(Vector2 direction)
    {
        dir = direction;
    }
}
