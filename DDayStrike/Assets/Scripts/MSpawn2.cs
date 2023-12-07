using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSpawn2 : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject enemyPrefab;  
    public Transform[] spawnPoints;  

    private bool hasSpawned = false;

    public int numberOfEnemies = 5;

    void Start()
    {
        SpawnPrefabsOnce();
        SpawnEnemies();
    }

    void Update()
    {
       
    }

    void SpawnPrefabsOnce()
    {
        if (!hasSpawned)
        {
            // Shuffle the spawn points array
            System.Random rng = new System.Random();
            int n = spawnPoints.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Transform value = spawnPoints[k];
                spawnPoints[k] = spawnPoints[n];
                spawnPoints[n] = value;
            }

            // Spawn all prefabs at random spawn points
            for (int i = 0; i < Mathf.Min(prefabs.Length, spawnPoints.Length); i++)
            {
                Instantiate(prefabs[i], spawnPoints[i].position, Quaternion.identity);
            }

            hasSpawned = true;
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Randomly select a spawn point
            Transform spawnPoint = GetRandomSpawnPoint();

            // Spawn an enemy at the selected spawn point
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    Transform GetRandomSpawnPoint()
    {
        // Randomly select a spawn point from the array
        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
    }
}
