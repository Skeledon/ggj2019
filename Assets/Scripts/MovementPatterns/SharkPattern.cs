using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkPattern : GenericMovement
{
    private Transform LeftBoundary;
    private Transform RightBoundary;
    private Transform BottomBoundary;
    public float VerticalTime;

    private int verticalDirection;
    private float horizontalBackup;

    private bool goingVertical;
    private bool lockVertical = false;

    private Coroutine coRoute;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y > 0)
            verticalDirection = -1;
        else
            verticalDirection = 1;

        RightBoundary = GameObject.FindGameObjectWithTag("RightCheck").transform;
        LeftBoundary = GameObject.FindGameObjectWithTag("LeftCheck").transform;
        BottomBoundary = GameObject.FindGameObjectWithTag("BottomCheck").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Speed * Time.deltaTime, Space.World);
        CheckBoundaries();
    }

    private void CheckBoundaries()
    {
        if (Mathf.Abs(transform.position.x - LeftBoundary.position.x) <= .2f && dir.x < 0 || Mathf.Abs(transform.position.x - RightBoundary.position.x) <= .2f && dir.x > 0)
        {
            if (!goingVertical)
            {
                horizontalBackup = -Mathf.Sign(dir.x);
                coRoute = StartCoroutine(VerticalMovement());

            }
        }
        if(transform.position.y < BottomBoundary.position.y)
        {
            dir = Vector2.right * horizontalBackup;
            dir.Normalize();
            goingVertical = true;
            lockVertical = true;
            StopAllCoroutines();
        }
    }

    public override void StartMoving(Vector2 direction)
    {
        dir = direction;
    }

    private IEnumerator VerticalMovement()
    {
        if (!lockVertical)
        {
            goingVertical = true;
            dir = Vector2.up * verticalDirection;
            yield return new WaitForSeconds(VerticalTime);
            dir = Vector2.right * horizontalBackup;
            dir.Normalize();
            goingVertical = false;
        }
    }
}
