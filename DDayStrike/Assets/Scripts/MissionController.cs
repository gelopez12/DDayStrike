using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    public GameObject Ring;
    public float xPos; //12f to 50f
    public float yPos = 3.38f;
    public float zPos; //35f to 165f
    public Vector3 spawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(Random.Range(12.0f, 50.0f), yPos, Random.Range(35.0f, 165.0f));
        Instantiate(Ring, spawnPos, Quaternion.Euler(0,0,90));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
