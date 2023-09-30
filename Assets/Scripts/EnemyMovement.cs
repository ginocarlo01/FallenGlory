using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float closeAttackDistance;

    private void Start()
    {
       player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(CalculateDistance() > closeAttackDistance)
        {
            MoveEnemy();
            //RotateEnemy();
        }
        
    }

    private float CalculateDistance()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        return distance;
    }

    private void MoveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void RotateEnemy()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
