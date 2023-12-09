using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    MissionController mcScript;
    public GameObject mc;
    public string sceneName;
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
            SceneManager.LoadScene(sceneName);
            
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
