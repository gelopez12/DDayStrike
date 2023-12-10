using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lvl1MissionUI : MonoBehaviour
{
    MissionController mcScript;
    PlayerController pcScript;
    public GameObject mc;
    public GameObject player;
    public GameObject firstMissions;
    public GameObject escortMissions;
    public GameObject promptTextObj;
    public GameObject percentTextObj;
    public Text reviveText;
    public Text retrieveText;
    public Text ambushText;
    public Text escortText;
    public Text defendText;
    public Text findText;
    public Text promptText;
    public Text percentText;
    public bool revive = false;
    public bool retrieve = false;
    public bool drop = false;
    public bool ambush = false;
    public bool escort = false;
    public bool defend = false;
    public bool reviveRing = false;
    public bool retrieveRing = false;
    public bool dropRing = false;
    public bool ambushRing = false;
    public bool escortRing = false;
    public bool atDoor = false;
    public float aPercent;
    public float dPercent;

    // Start is called before the first frame update
    void Start()
    {
        mcScript = mc.GetComponent<MissionController>();
        pcScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Green Text and Change Missions
        revive = mcScript.reviveDone;
        retrieve = mcScript.retrieveDone;
        drop = mcScript.dropDone;
        ambush = mcScript.ambushDone;
        escort = mcScript.escortDone;
        defend = mcScript.boom;

        //Text Prompts
        reviveRing = pcScript.inReviveRing;
        retrieveRing = pcScript.inRetrieveRing;
        dropRing = pcScript.inDropRing;
        ambushRing = pcScript.inAmbushRing;
        escortRing = pcScript.inEscortRing;
        atDoor = pcScript.doorTouch;
        aPercent = mcScript.ambushTime;
        dPercent = mcScript.bangTime;

        //Green Text and Change Missions
        if (revive)
        {
            reviveText.color = Color.green;
        }
        if (retrieve)
        {
            retrieveText.text = "Deliver the Bangalore";
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
        if (escort)
        {
            escortText.color = Color.green;
        }
        if (defend)
        {
            defendText.color = Color.green;
        }

        //Text Prompts
        if (reviveRing && !revive)
        {
            promptTextObj.SetActive(true);
            promptText.text = "Press [F] to Revive";
        } else if (retrieveRing)
        {
            promptTextObj.SetActive(true);
            promptText.text = "Press [F] to Retrieve Bangalore";
        } else if (dropRing)
        {
            promptTextObj.SetActive(true);
            promptText.text = "Press [F] to Deliver Bangalore";
        } else if (ambushRing)
        {
            promptTextObj.SetActive(true);
            percentTextObj.SetActive(true);
            promptText.text = "Holdout Inside Objective";
            percentText.text = UnityEngine.Mathf.Ceil(((aPercent / 10) * 100)) + "%";
        } else if (escortRing && !escort)
        {
            promptTextObj.SetActive(true);
            promptText.text = "Remain Inside Objective to Escort";

        }  else if (escortRing && escort)
        {
            promptTextObj.SetActive(true);
            percentTextObj.SetActive(true);
            promptText.text = "Defend the Objective";
            percentText.text = UnityEngine.Mathf.Ceil(((dPercent / 30) * 100)) + "%";
            if (dPercent == 0)
            {
                promptTextObj.SetActive(false);
                percentTextObj.SetActive(false);
            }
        } else if (atDoor)
        {
            promptTextObj.SetActive(true);
            promptText.text = "Press [F] to Enter the Bunker";
        } else
        {
            promptTextObj.SetActive(false);
            percentTextObj.SetActive(false);
        }
    }
}
