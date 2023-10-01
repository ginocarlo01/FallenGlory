using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float waitToDeathTime;
    [SerializeField] private float maxLife;
    private float life;
    public static PlayerLife instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        life = maxLife;
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
        UpdateUI();
        HandleDeath();
    }

    private void HandleDeath()
    {
        if(life <= 0)
        {
            UIManager.instance.DisableHP(); ;
            Die();
        }
    }

    public void UpLife(float value)
    {
        life += value;
        UpdateUI();
    }

    private void UpdateUI()
    {
        float partialLife = life / maxLife;

        UIManager.instance.UpdateHP(partialLife);
    }

}
