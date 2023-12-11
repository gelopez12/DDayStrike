using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager3 : MonoBehaviour
{
    PauseScript3 pauseScript3;
    public GameObject pause;
    public int c = 0;
    public string home;
    public Button returnButton;
    public Button controllsButton;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        pauseScript3 = pause.GetComponent<PauseScript3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            c = pauseScript3.control2;
        }    
            
    }

    public void ChangeSceneHome()
    {
        SceneManager.LoadScene(home);
    }

    public void ControllsMenu()
    {
        c = 1;
    }

    public void BackButtonPress()
    {
        c = 0;
    }
}
