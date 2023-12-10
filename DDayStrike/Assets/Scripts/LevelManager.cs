using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    MissionController mcScript;
    public GameObject mc;
    public GameObject Title;
    public GameObject lvlSelect;
    //public string sceneName;
    public string sceneName1;
    public string sceneName2;
    public string sceneName3;
    public Button Level1;
    public Button Level2;
    public Button Level3;
    public bool lvl2 = false;
    

    // Start is called before the first frame update
    void Start()
    {
        mcScript = mc.GetComponent<MissionController>();
    }

    // Update is called once per frame
    void Update()
    {
        lvl2 = mcScript.lvl2Access;
        if (lvl2 == true)
        {
            SceneManager.LoadScene(sceneName2);
            
        }
    }

    public void titleFalse()
    {
        Title.SetActive(false);
        lvlSelect.SetActive(true);
    }
    public void titleTrue()
    {
        Title.SetActive(true);
        lvlSelect.SetActive(false);
    }
    public void changeScene1()
    {
        SceneManager.LoadScene(sceneName1);
    }
    public void changeScene2()
    {
        SceneManager.LoadScene(sceneName2);
    }
    public void changeScene3()
    {
        SceneManager.LoadScene(sceneName3);
    }
}
