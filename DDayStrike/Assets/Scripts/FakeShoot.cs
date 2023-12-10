using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeShoot : MonoBehaviour
{
    
    public float shootInterval = 0.5f; // Adjust the interval as needed
    private float timer = 0f;

    
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component on the same GameObject or add one if none exists
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the timer each frame
        timer += Time.deltaTime;

        // Check if enough time has passed to shoot again
        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f; // Reset the timer
        }
    }

    void Shoot()
    {
        // Instantiate a new bullet at the current position and rotation of the shooter
        //Instantiate(BulletPre, transform.position, transform.rotation);

        audioSource.Play();
    }
}
