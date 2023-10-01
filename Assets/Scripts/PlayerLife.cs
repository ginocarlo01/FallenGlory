using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float waitToDeathTime;
    [SerializeField] private float life;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        StartCoroutine(DeathDelay());
    }

    private IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(waitToDeathTime); 

        RestartScene();
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        HandleDeath();
    }

    private void HandleDeath()
    {
        if(life <= 0)
        {
            Die();
        }
    }
}
