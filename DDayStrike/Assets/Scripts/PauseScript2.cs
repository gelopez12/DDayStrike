using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript2 : MonoBehaviour
{
    int i = 2;
    Shooting shooting;
    PlayerController playerController;
    MSpawn2 mSpawn2;
    Level2 level2;
    public GameObject player;
    public GameObject missionSpawn;

    // Start is called before the first frame update
    void Start()
    {
        shooting = player.GetComponent<Shooting>();
        playerController = player.GetComponent<PlayerController>();
        mSpawn2 = missionSpawn.GetComponent<MSpawn2>();
        level2 = player.GetComponent<Level2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            i++;
            if (i % 2 == 1)
            {
                shooting.enabled = false;
                playerController.enabled = false;
                mSpawn2.enabled = false;
                level2.enabled = false;
                Time.timeScale = 0;
            }
            else
            {
                shooting.enabled = true;
                playerController.enabled = true;
                mSpawn2.enabled = true;
                level2.enabled = true;
                Time.timeScale = 1;
            }
        }
    }
}
