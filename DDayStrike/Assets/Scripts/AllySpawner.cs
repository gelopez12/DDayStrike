using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 10.0f;

    void Start()
    {
        InvokeRepeating("SpawnAlly", 0f, spawnInterval);
    }

    void Update()
    {

    }
    void SpawnAlly()
    {
        // Check if there are valid spawn points
        if (spawnPoints.Length > 0)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];



            Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.Euler(0, 90, 0));
        }
    }

}
