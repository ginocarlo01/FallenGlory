using UnityEngine;

public class AttackObject : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float destroyTime = 5.0f;
    [SerializeField] private float damage;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyLife>().TakeDamage(damage);
        }
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    public void SetRange(float value)
    {
        destroyTime = value;
    }

    public void SetDamage(float value)
    {
        damage = value;
    }

}
