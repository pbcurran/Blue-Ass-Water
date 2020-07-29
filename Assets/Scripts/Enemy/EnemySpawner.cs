using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        float startTime = Time.time;
        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            float currentTime = Time.time;
            var currentWave = waveConfigs[waveIndex];

            if(currentWave.GetTimeUntilSpawn() != 0)
            {
                yield return new WaitForSeconds(currentWave.GetTimeUntilSpawn() - currentTime);
            }

            yield return StartCoroutine(SpawnallEnemiesInWave(currentWave));
            Debug.Log("finished one for loop");
        }
    }

    private int GetRandomNumber()
    {
        return Random.Range(0, 2);
    }

    private IEnumerator SpawnallEnemiesInWave(WaveConfig waveConfig)
    {
        
        // wait period for the wave to start so they arent all stacked on top of eachother
        // float timeUntilWave = waveConfig.GetTimeUntilSpawn();
        // yield return new WaitForSeconds(timeUntilWave);

        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            int enemySelection = GetRandomNumber();
            GameObject newEnemy;
            
            // need add a random number creator for one or two and thewn if statement for the instantiation of either the red or green depending on one or two
            if (enemySelection == 0)
            {
                newEnemy = Instantiate(waveConfig.GetBlueEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyAttributes>().SetWaveConfig(waveConfig);
            }
            else if (enemySelection == 1)
            {
                newEnemy = Instantiate(waveConfig.GetRedEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyAttributes>().SetWaveConfig(waveConfig);
            }

            yield return new WaitForSeconds(waveConfig.GetSpawnRandomFactor());
        }
        
    }
}
