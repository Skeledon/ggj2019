using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChelaHandler : MonoBehaviour
{
    public float TimeUntilDeactivation;


    public void Attack()
    {
        StartCoroutine(WaitForDeactivation());
    }

    private IEnumerator WaitForDeactivation()
    {
        yield return new WaitForSeconds(TimeUntilDeactivation);
        GetComponent<Collider2D>().enabled = false;
    }
}
