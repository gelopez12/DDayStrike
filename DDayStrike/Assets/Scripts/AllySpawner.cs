using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 2.0f;

    private List<Transform> availableSpawnPoints = new List<Transform>();

    void Start()
    {
        if (spawnPoints.Length > 0)
        {
            availableSpawnPoints.AddRange(spawnPoints);
            InvokeRepeating("SpawnAlly", 0f, spawnInterval);
        }
        else
        {
            Debug.LogError("No spawn points assigned to the AllySpawner!");
        }
    }

    void Update()
    {

    }

    void SpawnAlly()
    {
        // Check if there are available spawn points
        if (availableSpawnPoints.Count > 0)
        {
            // Get a random spawn point from the available list
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform randomSpawnPoint = availableSpawnPoints[randomIndex];

            // Instantiate the enemy at the selected spawn point
            Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.Euler(90, 0, 0));

            // Remove the used spawn point from the available list
            availableSpawnPoints.RemoveAt(randomIndex);
        }
        else
        {
            // If all spawn points have been used, reset the available list
            availableSpawnPoints.AddRange(spawnPoints);
        }
    }
}
