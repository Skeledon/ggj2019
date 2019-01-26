using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChelaHandler : MonoBehaviour
{
    public float TimeUntilDeactivation;


    public void Attack()
    {
        StartCoroutine(WaitForDeactivation());
        GetComponent<Collider2D>().enabled = true;
    }

    private IEnumerator WaitForDeactivation()
    {
        yield return new WaitForSeconds(TimeUntilDeactivation);
        GetComponent<Collider2D>().enabled = false;
    }
}
