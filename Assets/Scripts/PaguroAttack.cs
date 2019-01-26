using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaguroAttack : MonoBehaviour
{
    public GameObject PaguroAttackBox;
    public float TimeBetweenAttacks;

    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if(canAttack)
        {
            PaguroAttackBox.GetComponent<ChelaHandler>().Attack();
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        canAttack = false;
        yield return new WaitForSeconds(TimeBetweenAttacks);
        canAttack = true;
    }
}
