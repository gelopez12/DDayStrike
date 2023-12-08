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
    public GameObject AmbushRing;
    public GameObject ARingPrefab;
    public GameObject enemyPrefab;
    public GameObject RetrieveObj;
    public GameObject RetObjPrefab;
    public GameObject RetrieveRing;
    public GameObject RetRingPrefab;
    public GameObject DropRing;
    public GameObject DRPrefab;
    public Vector3 ringSpawnPos;
    public float downXPos;
    public float downYPos;
    public float downZPos;
    public Vector3 downPos;
    public float aRingX; //45f to 52f
    public float aRingY; // 3.37f
    public float aRingZ; //40f to 90f
    public float retXPos; // 30f to 50f
    public float retYPos; // 
    public float retZPos; //160f to 170f
    public Vector3 retrievePos;
    public float a;
    public int i;
    public bool revive;
    public bool reviveDone = false;
    public bool ambush;
    public float ambushTime = 0;
    public bool retrieve;
    public bool retrieval = false;
    public bool drop;
    public int missionNum = 0;

    void Start()
    {
        pcScript = player.GetComponent<PlayerController>();
        //a = 25.0f;


        //"Revive"
        downXPos = 8.0f;
        downYPos = 5.0f;
        downZPos = Random.Range(38.0f, 160.0f);
        downPos = new Vector3(downXPos, downYPos, downZPos);
        ringSpawnPos = new Vector3(downXPos, 4.11f, downZPos);
        DPPrefab = Instantiate(DownPlayer, downPos, Quaternion.Euler(90, 0, 0));
        RRingPrefab = Instantiate(ReviveRing, ringSpawnPos, Quaternion.Euler(0, 0, 90));

        //"Ambush"
        aRingX = Random.Range(45.0f, 52.0f);
        aRingY = 3.37f;
        aRingZ = Random.Range(40.0f, 90.0f);
        ringSpawnPos = new Vector3(aRingX, aRingY, aRingZ);
        ARingPrefab = Instantiate(AmbushRing, ringSpawnPos, Quaternion.Euler(0, 0, 90));
        for (int i = 0; i < 5; i++)
        {
            aRingX = Random.Range((aRingX - 1.5f), (aRingX + 1.5f));
            aRingZ = Random.Range((aRingZ - 1.5f), (aRingZ + 1.5f));
            Instantiate(enemyPrefab, new Vector3(aRingX, aRingY + 2.0f, aRingZ), Quaternion.identity);
        }

        //"Retrieve"
        retXPos = Random.Range(30.0f, 50.0f);
        retYPos = 4.77f;
        retZPos = Random.Range(160.0f, 170.0f);
        retrievePos = new Vector3(retXPos, retYPos, retZPos);
        ringSpawnPos = new Vector3(retXPos, 4.23f, retZPos);
        RetObjPrefab = Instantiate(RetrieveObj, retrievePos, Quaternion.identity);
        RetRingPrefab = Instantiate(RetrieveRing, ringSpawnPos, Quaternion.Euler(0, 0, 90));
    }

    // Update is called once per frame
    void Update()
    {
        //pcScript.Test(a);

        //"Revive"
        revive = pcScript.inReviveRing;
        if (!reviveDone)
        {
            if (revive == true && Input.GetKeyDown(KeyCode.F))
            {
                Destroy(RRingPrefab);
                DPPrefab.transform.Rotate(-90, 0, 0);
                DPPrefab.transform.position += new Vector3(0, 1, 0);
                missionNum++;
                reviveDone = true;
            }
        } 
        //"Ambush"
        ambush = pcScript.inAmbushRing;
        if (ambush == true && ambushTime < 10)
        {
            ambushTime += Time.deltaTime;
        }
        if (ambushTime >= 10)
        {
            ambushTime = 0;
            Destroy(ARingPrefab);
            missionNum++;
        }
        //"Retrieve"
        retrieve = pcScript.inRetrieveRing;
        if (retrieve == true && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(RetObjPrefab);
            Destroy(RetRingPrefab);
            retrieval = true;
            DRPrefab = Instantiate(DropRing, new Vector3(15.0f, 4.23f, 100.0f), Quaternion.Euler(0, 0, 90));
        }
        drop = pcScript.inDropRing; 
        if (retrieval == true && drop == true && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(DRPrefab);
            missionNum++;
        }
        
    }
}
