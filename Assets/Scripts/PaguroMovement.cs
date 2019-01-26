using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaguroMovement : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float JumpForce;
    public float SideSpeed;
    public float TimeBetweenJumps;
    public Transform VisualObject;
    public Animator myAnemoneAnimator;
    public Animator myPaguroAnimator;
    public Transform BottomCheck;

    private bool jumpEnabled;
    // Start is called before the first frame update
    void Start()
    {
        jumpEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jump(float direction)
    {
        if (jumpEnabled)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0);
            myRigidBody.AddForce(transform.up * JumpForce * direction, ForceMode2D.Impulse);
            myAnemoneAnimator.SetTrigger("Jump");
            StartCoroutine(WaitForNextJump());
        }
    }

    public void InterruptJump()
    {

            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y / 2);

    }

    public void Move(float direction)
    {
        if(Mathf.Abs(direction) > .1)
        {
            myPaguroAnimator.SetBool("Walking", true);
            if(transform.position.y > BottomCheck.position.y + 1)
                myPaguroAnimator.SetBool("Walking", false);

        }
        else
        {
            myPaguroAnimator.SetBool("Walking", false);
        }
        transform.Translate(Vector2.right * direction * SideSpeed * Time.deltaTime);
        if (direction < 0)
            VisualObject.rotation = Quaternion.Euler(0, 0, 0);
        if(direction > 0)
            VisualObject.rotation = Quaternion.Euler(0, 180, 0);
    }

    IEnumerator WaitForNextJump()
    {
        jumpEnabled = false;
        yield return new WaitForSeconds(TimeBetweenJumps);
        jumpEnabled = true;
    }


}
