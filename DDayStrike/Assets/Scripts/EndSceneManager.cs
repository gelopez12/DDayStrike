using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    public GameObject Title;
    public string home;
    public Button returnButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void titleFalse()
    {
        Title.SetActive(false);
    }
    public void titleTrue()
    {
        Title.SetActive(true);
    }
    public void changeSceneHome()
    {
        SceneManager.LoadScene(home);
    }
}
