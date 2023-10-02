using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private float meeleeSpeed;
    
    [SerializeField] private bool attackBlocked, canSuperAttack;
    [SerializeField] private float delay;

    [SerializeField] private GameObject attackObject, superAttackObject;

    [SerializeField] private float weaponSpeed, weaponRange, weaponDamage;

    public static PlayerAttack instance;

    private void Awake()
    {
        instance = this;
    }

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
        if (Input.GetKeyDown(KeyCode.Space) && canSuperAttack)
        {
            SuperAttack();
        }

        UIManager.instance.SetSuperAttackImage(canSuperAttack);


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

        UIManager.instance.SetAttackImage(!attackBlocked);
    }

    private void SuperAttack()
    {
        Instantiate(superAttackObject, transform.position, transform.rotation);
        DisableSuperAttack();
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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 

        Vector3 direction = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) - Mathf.PI / 2f;

        Quaternion rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);

        Instantiate(attackObject, transform.position, rotation);

        attackObject.GetComponent<AttackObject>().SetMoveSpeed(weaponSpeed);
        attackObject.GetComponent<AttackObject>().SetRange(weaponRange);
        attackObject.GetComponent<AttackObject>().SetDamage(weaponDamage);
    }

    public void SetWeaponSpeed(float value)
    {
        weaponSpeed += value;
    }

    public void SetWeaponRange(float value)
    {
        weaponRange += value;
    }

    public void SetWeaponDamage(float value)
    {
        weaponDamage += value;
    }

    public void EnableSuperAttack()
    {
        canSuperAttack = true;
    }

    private void DisableSuperAttack()
    {
        canSuperAttack = false;
    }
}
