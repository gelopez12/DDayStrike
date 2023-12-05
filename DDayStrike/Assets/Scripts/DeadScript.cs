using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScript : MonoBehaviour
{
    public AudioSource DeadScreen;
    // Start is called before the first frame update
    void Start()
    {
        DeadScreen.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the space bar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Load the "Level1" scene
            SceneManager.LoadScene("Level1");
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("HomeScreen");
        }

        // The following line will play the DeadScreen audio source in every frame.
        // If you want to play it under specific conditions, you might want to adjust this logic.
        
    }
}
