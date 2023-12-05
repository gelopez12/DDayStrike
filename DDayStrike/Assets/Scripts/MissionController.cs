using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    public GameObject Ring;
    public Vector3 spawnPos = new Vector3(13f, 3.38f, 145f);
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Ring, spawnPos, Quaternion.Euler(0,0,90));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
