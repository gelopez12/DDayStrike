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
            int prevSceneIndex = PlayerPrefs.GetInt("PrevSceneIndex", -1);

            if (prevSceneIndex >= 0)
            {
                SceneManager.LoadScene(prevSceneIndex);
            }
            else
            {
                Debug.LogWarning("No previous scene available.");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("HomeScreen");
        }
    }
}
