using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform[] spawnPoints; 
    public float spawnInterval = 20f; 

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void Update()
    {

    }
    void SpawnEnemy()
    {
        // Check if there are valid spawn points
        if (spawnPoints.Length > 0)
        {
            // Randomly choose a spawn point
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate the enemy at the chosen spawn point
            Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }
    }
}