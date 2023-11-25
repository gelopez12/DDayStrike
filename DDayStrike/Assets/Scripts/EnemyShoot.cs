using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    public float projectileSpeed = 200f;

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
            
            Vector3 direction = player.transform.position - firePoint.position;
            
            direction.Normalize();
           
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            projectileRb.AddForce(direction * projectileSpeed, ForceMode.Impulse);
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
