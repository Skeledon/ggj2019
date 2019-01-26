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

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Spawn(int FishIndex)
    {
        GameObject tmp = Instantiate(EnemiesPrefabs[FishIndex], transform.position, Quaternion.identity);
        tmp.GetComponent<GenericMovement>().StartMoving(transform.right);
    }
}
