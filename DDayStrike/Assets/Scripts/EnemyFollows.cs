using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollows : MonoBehaviour
{
    private GameObject player; 
    public float speed = 2.5f; 
     

    void Start()
    {
        FindPlayer(); 
    }

    void Update()
    {
        
        if (player != null)
        {
            
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0; 

            
            direction.Normalize();

            
            transform.position += direction * speed * Time.deltaTime;

            
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
