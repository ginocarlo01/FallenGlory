using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private float meeleeSpeed;
    [SerializeField] private float damage;

    float timeUntilMeelee;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (timeUntilMeelee <= 0f)
        {
            if (Input.GetMouseButton(0))
            {
                anim.SetTrigger("Attack");
                timeUntilMeelee = meeleeSpeed;
            }
        }
        else
        {
            timeUntilMeelee -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyLife>().TakeDamage(damage);
            //Debug.Log("Enemy hit");
        } 
    }
}
