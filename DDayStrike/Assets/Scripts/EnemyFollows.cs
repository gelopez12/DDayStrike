using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollows : MonoBehaviour
{
    public Transform player; // Reference to the main player's transform
    public float speed = 5f; // Speed at which the enemy follows the player

    void Update()
    {
        // Check if the player transform is assigned
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = player.position - transform.position;
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
}
