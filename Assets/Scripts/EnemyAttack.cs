using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int damage;

    [SerializeField] private int minDamageRandom, maxDamageRandom;

    private void Start()
    {
        GenerateDamage();
    }

    private void GenerateDamage()
    {
        damage = Random.Range(minDamageRandom, maxDamageRandom);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLife>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
