using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemoneHandler : MonoBehaviour
{
    public float TimeUntilDeactivation;
    public Transform Pivot;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(WaitForDeactivation());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator WaitForDeactivation()
    {
        yield return new WaitForSeconds(TimeUntilDeactivation);
        gameObject.SetActive(false);
    }
}
