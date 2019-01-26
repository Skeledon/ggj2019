using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Spawner[] Pesciolini;
    public Spawner[] PesciPalla;
    public Spawner[] Meduse;
    public Spawner[] Squali;

    public Level[] Levels;

    [System.Serializable]
    public struct Level
    {
        public float BaseSpawnProbability;
        public float BaseProbabilityIncreaseEachPoll;
        public float BaseProbabilityIncreaseOnEnemyDeath;
        public int MaxNumberOfEnemiesOnScreen;
        public float MinNumberOfEnemiesOnScreen;

        public FishSpawnData[] FishData;
    }

    [System.Serializable]
    public struct FishSpawnData
    {
        public float SpawnProbability;
        public int MaxNumberOfSameType;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
