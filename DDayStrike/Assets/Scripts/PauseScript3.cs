using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript3 : MonoBehaviour
{
    int i = 2;
    Shooting shooting;
    PlayerController playerController;
    Level3 level3;
    public GameObject level3Controller;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        shooting = player.GetComponent<Shooting>();
        playerController = player.GetComponent<PlayerController>();
        level3 = level3Controller.GetComponent<Level3>();
        /*enemyShoot = enemy.GetComponent<EnemyShoot>();
        enemyFollows = enemy.GetComponent<EnemyFollows>();*/
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
                level3.enabled = false;
                Time.timeScale = 0;
            }
            else
            {
                shooting.enabled = true;
                playerController.enabled = true;
                level3.enabled = true;
                Time.timeScale = 1;
            }
        }
    }
}