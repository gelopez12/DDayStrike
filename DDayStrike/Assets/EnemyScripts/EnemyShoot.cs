using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public GameObject projectilePrefab; // Prefab of the projectile to be shot
    public Transform firePoint;
    public float shootInterval = 10f; // Interval between shots
    public float projectileSpeed = 10f; // Speed of the projectile

    void Start()
    {
        // Start shooting at intervals
        InvokeRepeating("ShootAtPlayer", 0f, shootInterval);
    }

    void ShootAtPlayer()
    {
        if (player != null && firePoint != null)
        {
            // Calculate direction towards the player
            Vector3 direction = player.position - firePoint.position;

            // Normalize the direction to get a unit vector
            direction.Normalize();

            // Instantiate the projectile at the enemy's position
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Get the Rigidbody component of the projectile
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            // Apply force to shoot the projectile in the calculated direction
            projectileRb.AddForce(direction * projectileSpeed, ForceMode.Impulse);
        }
    }

}
