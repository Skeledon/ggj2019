using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] EnemiesPrefabs;
    public float TimeBetweenSpawnsMax;
    public float TimeBetweenSpawnsMin;

    // Start is called before the first frame update
    void OnEnable()
    {
        //StartCoroutine(WaitBetweenSpawns());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitBetweenSpawns()
    {
        yield return new WaitForSeconds(Random.Range(TimeBetweenSpawnsMin, TimeBetweenSpawnsMax));
        Spawn(0);
        StartCoroutine(WaitBetweenSpawns());
    }

    public void Spawn(int FishIndex)
    {
        GameObject tmp = Instantiate(EnemiesPrefabs[FishIndex], transform.position, Quaternion.identity);
        tmp.GetComponent<GenericMovement>().StartMoving(transform.right);
    }
}
