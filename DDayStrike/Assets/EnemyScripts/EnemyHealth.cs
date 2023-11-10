using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2; // Maximum health of the enemy

    private int currentHealth; // Current health of the enemy

    void Start()
    {
        currentHealth = maxHealth; // Set initial health
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a projectile
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Subtract health
            currentHealth--;

            // Check if the enemy is defeated
            if (currentHealth <= 0)
            {
                // Enemy defeated, stop and disappear
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
