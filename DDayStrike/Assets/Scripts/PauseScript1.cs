using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript1 : MonoBehaviour
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
    public GameObject controllsMenu;
    public Text pauseTitle;
    public Text pauseInstruction;
    public int control;
    public int control2;

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
                pauseTitle.text = "PAUSED";
                pauseInstruction.text = "[ESC] to Unpause";
                shooting.enabled = false;
                playerController.enabled = false;
                level3.enabled = false;
                unpaused.SetActive(false);
                paused.SetActive(true);
                Time.timeScale = 0;
            }
            else
            { //unpaused
                pauseTitle.text = "";
                pauseInstruction.text = "[ESC] to Pause";
                shooting.enabled = true;
                playerController.enabled = true;
                level3.enabled = true;
                unpaused.SetActive(true);
                paused.SetActive(false);
                controllsMenu.SetActive(false);
                Time.timeScale = 1;
                control2 = 0;
            }
        }

        if (control == 1 && i % 2 == 1)
        {
            paused.SetActive(false);
            controllsMenu.SetActive(true);
        }
        else if (control == 0 && i % 2 == 1)
        {
            paused.SetActive(true);
            controllsMenu.SetActive(false);
        }
    }
}