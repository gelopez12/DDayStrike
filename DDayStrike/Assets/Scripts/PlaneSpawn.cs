using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawn : MonoBehaviour
{

    public GameObject planePrefab;
    public float spawnInterval = 3.0f; // Spawn interval in seconds

    private float timer = 0.0f;
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new plane
        if (timer >= spawnInterval)
        {
            // Reset the timer
            timer = 0f;

            // Calculate a random spawn position
            Vector3 spawnPosition = new Vector3(0, 39, Random.Range(40,180));

            // Instantiate the plane at the calculated position
            Instantiate(planePrefab, spawnPosition, planePrefab.transform.rotation);
        }
    }
}
