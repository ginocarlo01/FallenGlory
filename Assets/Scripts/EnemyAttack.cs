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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("Attacked Player");
            collision.gameObject.GetComponent<PlayerLife>().TakeDamage(damage);
        }
    }
}
