using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyGreenPrefab;
    [SerializeField] GameObject enemyRedPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeUntilSpawn = 0f;
    [SerializeField] float timeBetweenSpawns = 0.5f;

    [SerializeField] float spawnRandomFactorMin = 0.6f;
    [SerializeField] float spawnRandomFactorMax = 0.6f;

    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 8f;

    [SerializeField] bool hasWaveSpawned = false;


    public bool GetWaveSpawnStatus()
    {
        return hasWaveSpawned;
    }
    public void SetWaveHasSpawned(bool waveStatus)
    {
        //Debug.Log("entered set wave spawn to wave status function");
        hasWaveSpawned = waveStatus;
        //Debug.Log("wave status is now: " + hasWaveSpawned);
    }

    public GameObject GetBlueEnemyPrefab()
    {
        return enemyGreenPrefab;
    }

    public GameObject GetRedEnemyPrefab()
    {
        return enemyRedPrefab;
    }

    // this used to give the gems path from the bottom to the top of the game, they dont actually get to the bottom though as there is the shredder
    // underneath
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetTimeUntilSpawn()
    {
        return timeUntilSpawn;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        float spawnRandomFactor = Random.Range(spawnRandomFactorMin, spawnRandomFactorMax);

        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
