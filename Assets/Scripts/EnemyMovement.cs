using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer sprite;

    [SerializeField] private float speed;
    [SerializeField] private float closeAttackDistance;
    

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
       player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(CalculateDistance() > closeAttackDistance)
        {
            MoveEnemy();
            
        }
        LookAtPlayer();
        
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

    private void LookAtPlayer()
    {
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = player.transform.position;

        if(enemyPos.x < playerPos.x)
        {
            sprite.flipX = false;
        }

        else
        {
            sprite.flipX = true;
        }
    }

    private void RotateEnemy()
    {
        Vector3 dir = player.transform.position - transform.position;

        // Calculate the angle (in degrees) from the direction vector.
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Calculate the dot product to determine if character is on the left or right side.
        float dot = Vector3.Dot(transform.right, dir.normalized);

        // Flip the angle if the character is on the left side.
        if (dot < 0.0f)
        {
            angle += 180.0f;
        }

        // Clamp the angle to ensure it doesn't exceed the specified range.
        angle = Mathf.Clamp(angle, -90, 90);

        // Apply the rotation only to the Z-axis (around the forward vector).
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }


}
