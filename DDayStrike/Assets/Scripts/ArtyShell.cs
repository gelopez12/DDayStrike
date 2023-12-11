using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtyShell : MonoBehaviour
{
    public ParticleSystem explosionParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    void OnCollisionEnter(Collision collision)
    {
        // Check if the artillery shell collides with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Play the explosion particle effect
            Instantiate(explosionParticleEffect, transform.position, Quaternion.identity);

            // Optionally, you can add additional logic here (e.g., damage to nearby objects, terrain deformation).

            // Destroy the artillery shell
            Destroy(gameObject);
        }
    }

}
