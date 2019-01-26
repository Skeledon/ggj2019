using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Spawner[] Pesciolini;
    public Spawner[] PesciPalla;
    public Spawner[] Meduse;
    public Spawner[] Squali;

    public EnemyList EnemyListScriptable;
    public float PollTime;

    public Level[] Levels;

    [System.Serializable]
    public struct Level
    {
        public float BaseSpawnProbability;
        public float BaseProbabilityIncreaseEachPoll;
        public float BaseProbabilityIncreaseForEnemyDead;
        public int MaxNumberOfEnemiesOnScreen;
        public float MinNumberOfEnemiesOnScreen;

        public FishSpawnData Pesciolino;
        public FishSpawnData PescePalla;
        public FishSpawnData Medusa;
        public FishSpawnData Squalo;
    }

    [System.Serializable]
    public struct FishSpawnData
    {
        public float SpawnProbability;
        public int MaxNumberOfSameType;
    }

    public int CurrentLevel;
    private int currentPoll;

    // Start is called before the first frame update
    void Start()
    {
        currentPoll = 0;
        StartCoroutine(MainPolling());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MainPolling()
    {
        float baseSpawn;
        while (true)
        {
            baseSpawn = CalculateBaseProbabilites();
            if (Random.value < baseSpawn)
            {
                SpawnFish( CalculateFish());
            }
            currentPoll++;
            yield return new WaitForSeconds(PollTime);
        }
    }

    private float CalculateBaseProbabilites()
    {
        Level lev = Levels[CurrentLevel];
        if(EnemyListScriptable.TotalAllFishes < lev.MinNumberOfEnemiesOnScreen)
        {
            return 1;
        }
        if (EnemyListScriptable.TotalAllFishes > lev.MaxNumberOfEnemiesOnScreen)
        {
            return 0;
        }
        float baseSpawn = lev.BaseSpawnProbability + lev.BaseProbabilityIncreaseForEnemyDead * (lev.MaxNumberOfEnemiesOnScreen - EnemyListScriptable.TotalAllFishes) + currentPoll * lev.BaseProbabilityIncreaseEachPoll;

        return baseSpawn;

    }

    private int CalculateFish()
    {
        Level lev = Levels[CurrentLevel];
        float[] fishes = new float[4];
        fishes[0] = lev.Pesciolino.SpawnProbability;
        fishes[1] = lev.PescePalla.SpawnProbability;
        fishes[2] = lev.Medusa.SpawnProbability;
        fishes[3] = lev.Squalo.SpawnProbability;

        float[] percentageModifiers = new float[4];
        percentageModifiers[0] = lev.Pesciolino.SpawnProbability / lev.Pesciolino.MaxNumberOfSameType;
        percentageModifiers[1] = lev.PescePalla.SpawnProbability / lev.PescePalla.MaxNumberOfSameType;
        percentageModifiers[2] = lev.Medusa.SpawnProbability / lev.Medusa.MaxNumberOfSameType;
        percentageModifiers[3] = lev.Squalo.SpawnProbability / lev.Squalo.MaxNumberOfSameType;

        int[] maxFishes = new int[4];
        maxFishes[0] = lev.Pesciolino.MaxNumberOfSameType;
        maxFishes[1] = lev.PescePalla.MaxNumberOfSameType;
        maxFishes[2] = lev.Medusa.MaxNumberOfSameType;
        maxFishes[3] = lev.Squalo.MaxNumberOfSameType;

        int[] countDifferentials = new int[4];
        countDifferentials[0] = EnemyListScriptable.TotalePesciolini;
        countDifferentials[1] = EnemyListScriptable.TotalePesciPalla;
        countDifferentials[2] = EnemyListScriptable.TotaleMeduse;
        countDifferentials[3] = EnemyListScriptable.TotaleSquali;

        for(int i = 0; i < 4; i++)
        {
            percentageModifiers[i] *= countDifferentials[i];
        }

        for(int i = 0; i< 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if (i == j)
                    fishes[j] -= percentageModifiers[i];
                else
                    fishes[j] += percentageModifiers[i] / 3;
            }
        }

        float rnd = Random.value;
        float currentPerc = 0;

        for (int i = 0; i< 4; i++)
        {
            if (maxFishes[i] == countDifferentials[i])
                fishes[i] = 0;
        }

        for(int i= 0; i<4;i++)
        {
            currentPerc += fishes[i];
            if (rnd < currentPerc)
                return i;
        }

        return 4;
    }

    private void SpawnFish(int n)
    {
        switch (n)
        {
            case 0:
                Pesciolini[Random.Range(0, Pesciolini.Length)].Spawn(n);
                break;
            case 1:
                PesciPalla[Random.Range(0, PesciPalla.Length)].Spawn(n);
                break;
            case 2:
                Meduse[Random.Range(0, Meduse.Length)].Spawn(n);
                break;
            case 3:
                Squali[Random.Range(0, Squali.Length)].Spawn(n);
                break;
            default:
                break;
        }
        currentPoll = 0;
    }
}
