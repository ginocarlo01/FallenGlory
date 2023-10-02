using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float health;
    private float upBorderScale;

    [SerializeField] private float maxUpBorderScale;
    [SerializeField] private float minUpBorderScale;

    [SerializeField] private float maxRandomHealth;
    [SerializeField] private float minRandomHealth;

    private bool tookDamage, noTookDamage;
    private float transitionTimer;
    [SerializeField] private float timeToShowDamage;
    [SerializeField] private float transparencyDamaged = 0.5f;
    private Color targetColor, startColor;

    private SpriteRenderer sprite;

    private void Start()
    {
        InitializeEnemy();
    }

    private void Update()
    {
        if (tookDamage) { AppearDamage(); }
        if (noTookDamage) { DisappearDamage(); }
    }

    private void InitializeEnemy()
    {
        sprite = GetComponent<SpriteRenderer>();
        startColor = sprite.color;
        targetColor = new Color(startColor.r, startColor.g, startColor.b, transparencyDamaged * startColor.a);
        maxRandomHealth = SpawnEnemiesManager.instance.GetMaxEnemyRandomLife();
        
        GenerateHealth();
        GenerateUpScale();
    }

    private void GenerateHealth()
    {
        
        health = Random.Range(minRandomHealth, maxRandomHealth);
    }

    private void GenerateUpScale()
    {
        upBorderScale = Random.Range(minUpBorderScale, maxUpBorderScale);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        tookDamage = true;
        HandleDeath();
    }

    private void HandleDeath()
    {
        if (health <= 0f)
        {
            EnemyKillManager.instance.KilledEnemy();
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
        UpBorder();
        ManaManager.instance.UpMana(1); ;
    }

    private void UpBorder()
    {
        BorderManager.instance.ScaleUpCircle(upBorderScale);
    }

    private void AppearDamage()
    {
        transitionTimer += Time.deltaTime;
        
        float porcentage = Mathf.Clamp01(transitionTimer / timeToShowDamage);
        Color lerpedColor = Color.Lerp(startColor, targetColor, porcentage);

        sprite.color = lerpedColor;

       

        if (porcentage >= 1f)
        {
            tookDamage = false;
            noTookDamage = true;
        }
    }

    private void DisappearDamage()
    {
        transitionTimer += Time.deltaTime;

        float porcentage = Mathf.Clamp01(transitionTimer / timeToShowDamage);

        Color lerpedColor = Color.Lerp(targetColor, startColor, porcentage);

        sprite.color = lerpedColor;

        if (porcentage >= 1f)
        {
            noTookDamage = false;
            transitionTimer = 0;
        }
    }
}
