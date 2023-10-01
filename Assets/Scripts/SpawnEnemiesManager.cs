using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesManager : MonoBehaviour
{
    [SerializeField] private string SpawnTag;
    [SerializeField] private float spawnInterval;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<GameObject> spawnPoints;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
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
        Instantiate(enemyChosen, spawnPoint.position, Quaternion.identity);
    }
}
