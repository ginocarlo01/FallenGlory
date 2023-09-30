using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float upScale;

    public void TakeDamage(float damage)
    {
        health -= damage;

        HandleLife();
    }

    private void HandleLife()
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
        BorderManager.instance.ScaleUpCircle(upScale);
    }
}
