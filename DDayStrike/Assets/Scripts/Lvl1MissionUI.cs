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
    PlayersHealth phScript;
    Shooting shootScript;
    public Text HP;
    public Text ammunition;
    public Text reload;
    public int health;
    public int maxiHealth;
    public float ammo;
    public GameObject mc;
    public GameObject player;
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
        phScript = player.GetComponent<PlayersHealth>();
        shootScript = player.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        maxiHealth = phScript.maxHealth;
        health = phScript.currentHealth;
        HP.text = "HP: " + health + " / " + maxiHealth;

        ammo = shootScript.Mag;
        ammunition.text = "Ammo: " + ammo + " / 10";
        if (ammo == 0)
        {
            reload.text = "Press [R] to Reload";
        }
        else
        {
            reload.text = "";
        }

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
            reviveText.text = "";
            retrieveText.text = "";
            ambushText.text = "";
            escortText.text = "Escort the Bangalore";
            defendText.text = "Defend the Bangalore";
            findText.text = "Find the Bunker Entrance";
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
            promptText.text = "Press [F] to Revive";
        } else if (retrieveRing)
        {
            promptText.text = "Press [F] to Retrieve Bangalore";
        } else if (dropRing)
        {
            promptText.text = "Press [F] to Deliver Bangalore";
        } else if (ambushRing)
        {
            promptText.text = "Holdout Inside Objective";
            percentText.text = UnityEngine.Mathf.Ceil(((aPercent / 10) * 100)) + "%";
        } else if (escortRing && !escort)
        {
            promptText.text = "Remain Inside Objective to Escort";

        }  else if (escortRing && escort)
        {
            promptText.text = "Defend the Objective";
            percentText.text = UnityEngine.Mathf.Ceil(((dPercent / 30) * 100)) + "%";
            if (dPercent == 0)
            {
                promptText.text = "";
                percentText.text = "";
            }
        } else if (atDoor)
        {
            promptText.text = "Press [F] to Enter the Bunker";
        } else
        {
            promptText.text = "";
            percentText.text = "";
        }
    }
}
