using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject bullet3Prefab;
    public int maxHealth = 1; 
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; 
       
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                //EnemySpawner.OnEnemyKilled?.Invoke();
                

                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
