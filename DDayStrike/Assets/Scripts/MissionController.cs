using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    public GameObject player;
    PlayerController pcScript;
    public GameObject DownPlayer;
    public GameObject DPPrefab;
    public GameObject Ring;
    public GameObject ReviveRing;
    public GameObject RRingPrefab;
    public float ringXPos; //12f to 50f
    public float ringYPos = 3.38f;
    public float ringZPos; //35f to 165f
    public Vector3 ringSpawnPos;
    public float downXPos;
    public float downYPos;
    public float downZPos;
    public Vector3 downPos;
    public float a;
    public bool revive;
    // Start is called before the first frame update
    void Start()
    {
        pcScript = player.GetComponent<PlayerController>();
        a = 25.0f;
        //Testing Ring Spawn
        //ringSpawnPos = new Vector3(Random.Range(12.0f, 50.0f), ringYPos, Random.Range(35.0f, 165.0f));
        //Instantiate(Ring, ringSpawnPos, Quaternion.Euler(0,0,90));

        //Testing "Revive"
        downXPos = 8.0f;
        downYPos = 5.0f;
        downZPos = Random.Range(38.0f, 160.0f);
        downPos = new Vector3(downXPos, downYPos, downZPos);
        ringSpawnPos = new Vector3(downXPos, 4.11f, downZPos);
        DPPrefab = Instantiate(DownPlayer, downPos, Quaternion.Euler(90, 0, 0));
        RRingPrefab = Instantiate(ReviveRing, ringSpawnPos, Quaternion.Euler(0, 0, 90));

    }

    // Update is called once per frame
    void Update()
    {
        //pcScript.Test(a);
        revive = pcScript.inReviveRing;
        if (revive == true && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(RRingPrefab);
            DPPrefab.transform.Rotate(-90, 0, 0);
            DPPrefab.transform.position += new Vector3(0, 2, 0);
        }
    }
}
