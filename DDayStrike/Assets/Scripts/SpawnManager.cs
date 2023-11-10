using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 0;
    public float randomX;
    public float spawnY = 10.0f;
    public float randomZ;
    public Vector3 spawnPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (enemyCount < 40)
        {
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemyCount++;
        }
    }
}
