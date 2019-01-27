using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageApplier : MonoBehaviour
{
    public int DamageValue;
    public bool HitEnemyHittable;
    public bool HitPlayerHittable;
    public HP myHP;
    public ScoreHandler myScore;

    // Start is called before the first frame update
    void Start()
    {
        if(myScore)
            myScore.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int heal;
        if (collision.CompareTag("EnemyHittable") && HitEnemyHittable || collision.CompareTag("PlayerHittable") && HitPlayerHittable)
        {
            heal = collision.GetComponent<HP>().Modify(DamageValue);
            if ( myHP )
            {
                myHP.Modify(heal, true);
                myScore.AddScore(heal);
            }
        }
    }
}
