using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager3 : MonoBehaviour
{
    public int c = 0;
    public string home;
    public Button returnButton;
    public Button controllsButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneHome()
    {
        SceneManager.LoadScene(home);
    }

    public void ControllsMenu()
    {
        c = 1;
    }
}
