using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyToSpawn;
    public float TimeBetweenSpawnsMax;
    public float TimeBetweenSpawnsMin;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(WaitBetweenSpawns());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitBetweenSpawns()
    {
        yield return new WaitForSeconds(Random.Range(TimeBetweenSpawnsMin, TimeBetweenSpawnsMax));
        Spawn();
        StartCoroutine(WaitBetweenSpawns());
    }

    private void Spawn()
    {
        GameObject tmp = Instantiate(EnemyToSpawn, transform.position, Quaternion.identity);
        tmp.GetComponent<GenericMovement>().StartMoving(transform.right);
    }
}
