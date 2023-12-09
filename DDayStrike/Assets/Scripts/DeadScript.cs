using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScript : MonoBehaviour
{
    public AudioSource DeadScreen;
    LevelManager Respawn;
    //public GameObject RIP;
    public int RespawnLv;
    // Start is called before the first frame update
    void Start()
    {
        DeadScreen.Play();
        Respawn = GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RespawnLv = Respawn.LevelRespawn;
        // Check for the space bar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Load the "Level1" scene
            if (RespawnLv == 1)
            {
                SceneManager.LoadScene("Level1");
            }
            else if(RespawnLv == 2)
            {
                SceneManager.LoadScene("Level2");
            }
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("HomeScreen");
        }

        // The following line will play the DeadScreen audio source in every frame.
        // If you want to play it under specific conditions, you might want to adjust this logic.
        
    }
}
