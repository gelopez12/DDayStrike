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
    public GameObject EscortRing;
    public GameObject ERingPrefab;
    public GameObject BangWire;
    public GameObject BWPrefab;
    public Vector3 ringSpawnPos;
    public GameObject BunkerDoor;
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
    public float ERSpeed = 3.0f;
    public float eRingX;
    public float eRingY;
    public float eRingZ;
    public float a;
    public int num;
    public int i;
    public bool revive;
    public bool reviveDone = false;
    public bool ambush;
    public bool ambushDone = false;
    public float ambushTime = 0;
    public bool retrieve;
    public bool retrieval = false;
    public bool retrieveDone = false;
    public bool drop;
    public bool dropDone = false;
    public bool escort;
    public bool escortDone = false;
    public bool boom = false;
    public bool door = false;
    public float bangTime = 0;
    public int missionNum = 0;
    public bool lvl2Access = false;
    private Animator up;
    private Vector3 door1 = new Vector3(118.5f, 16f, 158f);
    private Vector3 door2 = new Vector3(115.8f, 16f, 92f);
    private Vector3 door3 = new Vector3(124f, 16f, 39.27f);


    void Start()
    {
        pcScript = player.GetComponent<PlayerController>();
        BWPrefab = Instantiate(BangWire, new Vector3(71.7f, 4.4f, 100f), Quaternion.Euler(0, 90, 0));

        up = GetComponent<Animator>();

        //a = 25.0f;


        //"Revive"
        downXPos = 8.0f;
        downYPos = 5.0f;
        downZPos = Random.Range(38.0f, 160.0f);
        downPos = new Vector3(downXPos, downYPos, downZPos);
        ringSpawnPos = new Vector3(downXPos, 4.11f, downZPos);
        DPPrefab = Instantiate(DownPlayer, downPos, Quaternion.Euler(0, 0, 0));
        RRingPrefab = Instantiate(ReviveRing, ringSpawnPos, Quaternion.Euler(0, 0, 90));

        //"Ambush"
        aRingX = Random.Range(45.0f, 52.0f);
        aRingY = 3.37f;
        aRingZ = Random.Range(40.0f, 90.0f);
        ringSpawnPos = new Vector3(aRingX, aRingY, aRingZ);
        ARingPrefab = Instantiate(AmbushRing, ringSpawnPos, Quaternion.Euler(0, 0, 90));

        //"Retrieve"
        retXPos = Random.Range(30.0f, 50.0f);
        retYPos = 4.77f;
        retZPos = Random.Range(160.0f, 170.0f);
        retrievePos = new Vector3(retXPos, retYPos, retZPos);
        ringSpawnPos = new Vector3(retXPos, 4.23f, retZPos);
        RetObjPrefab = Instantiate(RetrieveObj, retrievePos, Quaternion.identity);
        RetRingPrefab = Instantiate(RetrieveRing, ringSpawnPos, Quaternion.Euler(0, 0, 90));

        //"Escort/Bangalore"
        eRingX = 9.4f;
        eRingY = 3.38f;
        eRingZ = 100f;

        //Door Spawn
        num = Random.Range(1, 4);
        if (num == 1)
        {
            Instantiate(BunkerDoor, door1, Quaternion.Euler(0, -23, 0));
        }
        else if (num == 2)
        {
            Instantiate(BunkerDoor, door2, Quaternion.Euler(0, -2, 0));
        }
        else
        {
            Instantiate(BunkerDoor, door3, Quaternion.Euler(0, -167, 0));
        }
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
                up.SetBool("IsUP", true);
            }
        } 
        //"Ambush"
        ambush = pcScript.inAmbushRing;
        if (ambush == true && ambushTime < 10)
        {
            if (ambushTime < .075f)
            {
                aRingX = aRingX + 5.0f;
                aRingZ = Random.Range((aRingZ - 4.0f), (aRingZ + 4.0f));
                Instantiate(enemyPrefab, new Vector3(aRingX, aRingY + 2.0f, aRingZ), Quaternion.identity);
                aRingX = aRingX - 5.0f;
            }
            ambushTime += Time.deltaTime;
        }
        if (ambushTime >= 10)
        {
            ambushDone = true;
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
            retrieveDone = true;
            retrieval = true;
            DRPrefab = Instantiate(DropRing, new Vector3(15.0f, 4.23f, 100.0f), Quaternion.Euler(0, 0, 90));
        }
        drop = pcScript.inDropRing; 
        if (retrieval == true && drop == true && Input.GetKeyDown(KeyCode.F))
        {
            dropDone = true;
            Destroy(DRPrefab);
            missionNum++;
        }
        //"Escort/Bangalore"
        escort = pcScript.inEscortRing;
        if (missionNum == 3)
        {
            missionNum = 0;
            ERingPrefab = Instantiate(EscortRing, new Vector3(9.4f, 3.38f, 100f), Quaternion.Euler(0, 0, 90));
        }
        if (escort == true && !escortDone )
        {
            eRingX = eRingX + .01f;
            ERingPrefab.transform.position = new Vector3(eRingX, eRingY, eRingZ);
        }
        if (eRingX >= 67.0f)
        {
            escortDone = true;
        }
        if (escort == true && escortDone == true)
        {
            if (bangTime > 30.0f)
            {
                Destroy(ERingPrefab);
                Destroy(BWPrefab);
                boom = true;
                escort = false;
            } else if (bangTime <= 30.0f && !boom)
            {
                bangTime += Time.deltaTime;
            }
        }
        //Door
        door = pcScript.doorTouch;
        if (door == true && boom == true && Input.GetKeyDown(KeyCode.F))
        {
            lvl2Access = true;
        }

    }
}
