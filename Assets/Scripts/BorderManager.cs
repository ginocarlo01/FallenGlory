using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderManager : MonoBehaviour
{
    [SerializeField] private float reduceSpeed;
    [SerializeField] private float upSpeed;

    [SerializeField] private bool isGrowing;

    [SerializeField] private Vector3 targetUpScale;
    [SerializeField] private float maxScale;
    [SerializeField] private float minimumScale;
    [SerializeField] private Vector3 maxUpScale;
    [SerializeField] private Vector3 targetDownScale;

    private SpawnEnemiesManager spawn;
    public static BorderManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        spawn = GetComponent<SpawnEnemiesManager>();
        targetDownScale = minimumScale * new Vector3(1, 1, 1);
        maxUpScale = maxScale * new Vector3(1, 1, 1);
    }
    void Update()
    {
       
        if (isGrowing)
        {
            GrowCircle();
        }
        else
        {
            ReduceCircle();
        }
        

    }

    private void GrowCircle()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetUpScale, upSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.localScale, targetUpScale) < 0.1f)
        {
            OnTargetReached();
        }
    }

    private void ReduceCircle()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetDownScale, reduceSpeed * Time.deltaTime);
    }

    public void ScaleUpCircle(float upScale)
    {
        float localScale_ = transform.localScale.x;
        float newScale = localScale_ + upScale;

        if(newScale > maxScale)
        {
            targetUpScale = maxUpScale;
        }
        else
        {
            targetUpScale = transform.localScale + new Vector3(1, 1, 1) * upScale;
        }

       

        isGrowing = true;
    }

    private void OnTargetReached()
    {
        isGrowing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerLife>().Die();
        }

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyLife>().Die();
        }

        if (collision.tag == "Spawn")
        {
            spawn.HandleSpawn(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }

}
