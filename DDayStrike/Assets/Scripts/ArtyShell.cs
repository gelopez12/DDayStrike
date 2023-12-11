using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtyShell : MonoBehaviour
{
    public ParticleSystem explosionParticleEffect;
    public AudioSource explosionSound;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the artillery shell collides with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Play the explosion particle effect
            Instantiate(explosionParticleEffect, transform.position, Quaternion.identity);

            // Play the explosion sound if an audio source is provided and the clip is assigned
            if (explosionSound != null && explosionSound.clip != null)
            {
                explosionSound.Play();
            }
            else
            {
                Debug.LogWarning("Explosion sound or clip is not set.");
            }

            // Destroy the artillery shell after 5 seconds
            Destroy(gameObject, 2f);

            // Optionally, you can add additional logic here (e.g., damage to nearby objects, terrain deformation).
        }
    }  
}
