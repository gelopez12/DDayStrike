using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSpawn2 : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public int numberOfEnemies = 5;
    public float spawnInterval = 3f; // Adjust this value for the time between enemy spawns

    private bool hasSpawned = false;

    void Start()
    {
        StartCoroutine(SpawnEnemiesWithInterval());
    }

    void Update()
    {
        // Your update logic here
    }

    IEnumerator SpawnEnemiesWithInterval()
    {
        SpawnPrefabsOnce();

        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            SpawnEnemies();
        }
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
        // Shuffle the spawn points array for each enemy spawn
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

        // Randomly select a spawn point for the current enemy spawn
        Transform spawnPoint = spawnPoints[0]; // Use spawnPoints[0] since the array is shuffled

        // Spawn an enemy at the selected spawn point
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
