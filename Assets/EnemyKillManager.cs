using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillManager : MonoBehaviour
{
    [SerializeField] private int enemiesKilled = 0;

    public static EnemyKillManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void KilledEnemy()
    {
        enemiesKilled++;
    }

    public int GetEnemyCount()
    {
        return enemiesKilled;
    }
}
