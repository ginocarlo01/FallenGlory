using UnityEngine;

public class AttackObject : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Adjust this to set the upward velocity
    public float destroyTime = 5.0f; // Time in seconds before the object is destroyed
    [SerializeField] private float damage;

    private void Start()
    {
        // Start the destruction countdown
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        // Move the object upwards
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyLife>().TakeDamage(damage);
            //Debug.Log("Enemy hit");
        }
    }

}
