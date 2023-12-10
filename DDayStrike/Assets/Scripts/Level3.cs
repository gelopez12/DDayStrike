using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public GameObject landmine;
    public GameObject landminePrefab;
    public GameObject player;
    public GameObject enemy;
    public GameObject enemyPrefab;
    PlayerController pcScript;

    // Start is called before the first frame update
    void Start()
    {
        pcScript = player.GetComponent<PlayerController>();
        enemyPrefab = Instantiate(enemy, new Vector3(32f, 10.1f, 85f), Quaternion.identity);
        landminePrefab = Instantiate(landmine, new Vector3(26f, 10.1f, 75f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
