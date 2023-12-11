using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript3 : MonoBehaviour
{
    int i = 2;
    Shooting shooting;
    PlayerController playerController;
    Level3 level3;
    SceneManager3 sceneManager3;
    public GameObject level3Controller;
    public GameObject player;
    public GameObject sceneManager;
    public GameObject paused;
    public GameObject unpaused;
    public int control;

    // Start is called before the first frame update
    void Start()
    {
        shooting = player.GetComponent<Shooting>();
        playerController = player.GetComponent<PlayerController>();
        level3 = level3Controller.GetComponent<Level3>();
        sceneManager3 = sceneManager.GetComponent<SceneManager3>();
    }

    // Update is called once per frame
    void Update()
    {
        control = sceneManager3.c;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            i++;
            if (i % 2 == 1)
            { //paused
                shooting.enabled = false;
                playerController.enabled = false;
                level3.enabled = false;
                unpaused.SetActive(false);
                paused.SetActive(true);
                Time.timeScale = 0;
                if (control == 1)
                {

                }
            }
            else
            { //unpaused
                shooting.enabled = true;
                playerController.enabled = true;
                level3.enabled = true;
                unpaused.SetActive(true);
                paused.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}