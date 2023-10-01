using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private float health;
    private float upBorderScale;

    [SerializeField] private float maxUpBorderScale;
    [SerializeField] private float minUpBorderScale;

    [SerializeField] private float maxRandomHealth;
    [SerializeField] private float minRandomHealth;

    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        GenerateHealth();
        GenerateUpScale();
    }

    private void GenerateHealth()
    {
        health = Random.Range(minRandomHealth, maxRandomHealth);
    }

    private void GenerateUpScale()
    {
        upBorderScale = Random.Range(minUpBorderScale, maxUpBorderScale);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        HandleDeath();
    }

    private void HandleDeath()
    {
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
        UpBorder();
    }

    private void UpBorder()
    {
        BorderManager.instance.ScaleUpCircle(upBorderScale);
    }
}
