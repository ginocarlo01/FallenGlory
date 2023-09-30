using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesManager : MonoBehaviour
{
    [SerializeField] private string SpawnTag;
    [SerializeField] private float spawnInterval;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] List<GameObject> spawnPoints;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
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

        // Choose a random spawn point from the array.
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)].transform;

        // Instantiate the enemy at the chosen spawn point.
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
