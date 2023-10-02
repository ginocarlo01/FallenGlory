using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnPoint : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] private float timeToStartSpawn = 1f;

    private Color startColor;
    private float transitionTimer;
    private Color targetColor;
    private GameObject enemyChosen;

    private bool canSpawn, cantSpawn;

    private void Start()
    {
        InitializeSpawn();
    }

    private void InitializeSpawn()
    {
        sprite = GetComponent<SpriteRenderer>();
        startColor = sprite.color;
        startColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        targetColor = sprite.color;
        sprite.color = startColor;
    }

    private void Update()
    {
        if (canSpawn) { ShowSpawn(); }
        if (cantSpawn) { UnshowSpawn();  }
    }

    public void StartSpawn(GameObject enemy)
    {
        canSpawn = true;
        enemyChosen = enemy;
    }

    private void ShowSpawn()
    {
        transitionTimer += Time.deltaTime;
        
        float porcentage = Mathf.Clamp01(transitionTimer / timeToStartSpawn);

        Color lerpedColor = Color.Lerp(startColor, targetColor, porcentage);

        sprite.color = lerpedColor;

        if(porcentage >= 1f) { SpawnEnemy(); }
    }

    private void SpawnEnemy()
    {
        transitionTimer = 0;
        Instantiate(enemyChosen, transform.position, transform.rotation);
        StopSpawn();
    }

    private void StopSpawn()
    {
        canSpawn = false;
        cantSpawn = true;
    }

    private void UnshowSpawn()
    {
        transitionTimer += Time.deltaTime;

        float porcentage = Mathf.Clamp01(transitionTimer / timeToStartSpawn);

        Color lerpedColor = Color.Lerp(targetColor, startColor, porcentage);

        sprite.color = lerpedColor;

        if (porcentage >= 1f) 
        { 
            cantSpawn = false;
            transitionTimer = 0;
        }

        
    }

}
