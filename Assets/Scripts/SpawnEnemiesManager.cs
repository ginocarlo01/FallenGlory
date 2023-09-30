using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesManager : MonoBehaviour
{
    [SerializeField] private string SpawnTag;
    [SerializeField] List<GameObject> spawnPoints;

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
}
