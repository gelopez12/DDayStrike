using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    public float projectileSpeed = 200f;
    public float shootingRange = 50f; // Adjust this value based on your desired shooting range
    public AudioSource EnShoot;
    private GameObject player;

    void Start()
    {
        FindPlayer();
        InvokeRepeating("ShootAtPlayer", 0f, shootInterval);
    }

    void ShootAtPlayer()
    {
        if (player != null && firePoint != null)
        {
            // Check the distance between the enemy and the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= shootingRange)
            {
                EnShoot.Play();
                Vector3 direction = player.transform.position - firePoint.position;
                direction.Normalize();

                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

                Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
                projectileRb.AddForce(direction * projectileSpeed, ForceMode.Impulse);
            }
        }
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player is tagged with 'Player'.");
        }
    }
}
