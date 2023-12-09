using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lvl1MissionUI : MonoBehaviour
{
    MissionController mcScript;
    public GameObject mc;
    public GameObject firstMissions;
    public GameObject escortMissions;
    public Text reviveText;
    public Text retrieveText;
    public Text ambushText;
    public Text escortText;
    public bool revive = false;
    public bool retrieve = false;
    public bool drop = false;
    public bool ambush = false;

    // Start is called before the first frame update
    void Start()
    {
        mcScript = mc.GetComponent<MissionController>();
    }

    // Update is called once per frame
    void Update()
    {
        revive = mcScript.reviveDone;
        retrieve = mcScript.retrieveDone;
        drop = mcScript.dropDone;
        ambush = mcScript.ambushDone;

        if (revive)
        {
            reviveText.color = Color.green;
        }
        if (retrieve)
        {
            retrieveText.text = "Deliver the Bangalore ";
        }
        if (drop)
        {
            retrieveText.color = Color.green;
        }
        if (ambush)
        {
            ambushText.color = Color.green;
        }

        if (revive && drop && ambush)
        {
            firstMissions.SetActive(false);
            escortMissions.SetActive(true);
            ambush = false;
        }
    }
}
