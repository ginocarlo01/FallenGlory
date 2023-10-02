using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesManager : MonoBehaviour
{
    [SerializeField] private string SpawnTag;
    [SerializeField] private float spawnInterval;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private float spawnTimerDecreaseRate = 0.02f;
    [SerializeField] private float minSpawnTimer = 1.0f, maxEnemyLifeOnSpawn = 3, maxEnemyLife = 20, enemyLifeUpRate = 25, enemyLifeSpawnUpRate = 2;
    private bool alreadyUpgradedMaxLife;
    [SerializeField] private float enemiesKilled, localEnemyCount;

    public static SpawnEnemiesManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    private void Update()
    {
        CheckEnemiesKilled();
    }

    public void AddSpawnPoint(GameObject spawnPoint)
    {
        spawnPoints.Add(spawnPoint);
    }

    public void DeleteSpawnPoint(GameObject spawnPoint)
    {
        spawnPoints.Remove(spawnPoint);
    }

    public void HandleSpawn(GameObject spawnPoint)
    {
        if (spawnPoints.Contains(spawnPoint))
        {
            DeleteSpawnPoint(spawnPoint);
        }
        else
        {
            AddSpawnPoint(spawnPoint);
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.LogWarning("No spawn points defined!");
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)].transform;
        GameObject enemyChosen = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        spawnPoint.GetComponent<SpawnPoint>().StartSpawn(enemyChosen);
    }

   public void UpdateTimer()
    {
        if (spawnInterval > minSpawnTimer)
        {
            int numberOfEnemiesKilled = EnemyKillManager.instance.GetEnemyCount();
            spawnInterval -= numberOfEnemiesKilled * spawnTimerDecreaseRate;
        }
    }

    public void UpdateMaxEnemyLife()
    {
        if(maxEnemyLifeOnSpawn < maxEnemyLife && EnemyKillManager.instance.GetEnemyCount() % enemyLifeUpRate == 0)
        {
            Debug.Log(EnemyKillManager.instance.GetEnemyCount() % enemyLifeUpRate);
            maxEnemyLifeOnSpawn += enemyLifeSpawnUpRate;
        }
    }

    private void CheckEnemiesKilled()
    {
        localEnemyCount = EnemyKillManager.instance.GetEnemyCount();

        if (localEnemyCount != enemiesKilled)
        {
            UpdateTimer();
            enemiesKilled = localEnemyCount;
        }

    }

    public float GetMaxEnemyRandomLife()
    {
        Debug.Log("Max life: " + maxEnemyLifeOnSpawn);
        return maxEnemyLifeOnSpawn;
    }
}
