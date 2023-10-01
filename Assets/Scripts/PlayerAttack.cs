using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private float meeleeSpeed;
    
    [SerializeField] private bool attackBlocked;
    [SerializeField] private float delay;

    [SerializeField] private GameObject attackObject;

    float timeUntilMeelee;

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
            
        /*if (timeUntilMeelee <= 0f)
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
        }*/
    }

    

    private void Attack()
    {
        if (attackBlocked)
        {
            return;
        }
        SpawnAttackObject();
        attackBlocked = true;
        StartCoroutine(DelayAttack());

    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    private void SpawnAttackObject()
    {
        // Get the mouse cursor's position in the world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z-coordinate is appropriate for your game

        // Calculate the direction from the object to the mouse cursor
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calculate the rotation angle in radians with a 90-degree adjustment
        float angle = Mathf.Atan2(direction.y, direction.x) - Mathf.PI / 2f;

        // Convert the angle to degrees and create a rotation quaternion
        Quaternion rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);

        // Instantiate the object at the current position with the calculated rotation
        Instantiate(attackObject, transform.position, rotation);
    }
}
