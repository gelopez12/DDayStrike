using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollows : MonoBehaviour
{
    private GameObject player; // Reference to the player GameObject
    public float speed = 5f; // Speed at which the enemy follows the player

    void Start()
    {
        FindPlayer(); // Automatically find the player at the start
    }

    void Update()
    {
        // Check if the player GameObject is assigned
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0; // Keep the movement on the horizontal plane

            // Normalize the direction to get a unit vector
            direction.Normalize();

            // Move the enemy towards the player
            transform.position += direction * speed * Time.deltaTime;

            // Optionally, you can rotate the enemy to face the player
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            }
        }
    }

    void FindPlayer()
    {
        // Find the player by tag (adjust the tag accordingly)
        player = GameObject.FindGameObjectWithTag("Player");

        // You can add additional checks or error handling here
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player is tagged with 'Player'.");
        }
    }
}
