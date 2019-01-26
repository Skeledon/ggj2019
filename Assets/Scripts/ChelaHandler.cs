using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChelaHandler : MonoBehaviour
{
    public float TimeUntilDeactivation;

    public Animator myAnimator;


    public void Attack()
    {
        StartCoroutine(WaitForDeactivation());
        GetComponent<Collider2D>().enabled = true;
        myAnimator.SetTrigger("Attack");
    }

    private IEnumerator WaitForDeactivation()
    {
        yield return new WaitForSeconds(TimeUntilDeactivation);
        GetComponent<Collider2D>().enabled = false;
    }
}
