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
        //I wish there was a better way to do this, but Random would be so messy and buggy :(
        pcScript = player.GetComponent<PlayerController>();
        enemyPrefab = Instantiate(enemy, new Vector3(54f, 10.1f, 85f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(52f, 10.1f, 88f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(52f, 10.1f, 67f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(58f, 10.1f, 70f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(58f, 10.1f, 78f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(72f, 10.1f, 75f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(72f, 10.1f, 78f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(68f, 10.1f, 83f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(79f, 10.1f, 90f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(81f, 10.1f, 88f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(81f, 10.1f, 80f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(78f, 10.1f, 66f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(78f, 10.1f, 72f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(85f, 10.1f, 70f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(90f, 10.1f, 65f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(90f, 10.1f, 75f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(93f, 10.1f, 71f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(86f, 10.1f, 80f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(69f, 10.1f, 90f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(92f, 10.1f, 83f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(92f, 10.1f, 91f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(97f, 10.1f, 87f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(97f, 10.1f, 90f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(105f, 10.1f, 86f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(99f, 10.1f, 79f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(99f, 10.1f, 71f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(94f, 10.1f, 74f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(103f, 10.1f, 75f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(107f, 10.1f, 68f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(118f, 10.1f, 65f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(107f, 10.1f, 74f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(113f, 10.1f, 71f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(113f, 10.1f, 78f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(119f, 10.1f, 72f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(123f, 10.1f, 79f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(119f, 10.1f, 83f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(111f, 10.1f, 88f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(118f, 10.1f, 90f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(126f, 10.1f, 88f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(132f, 10.1f, 90f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(132f, 10.1f, 85f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(132f, 10.1f, 72f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(126f, 10.1f, 68f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(129f, 10.1f, 77f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(138f, 10.1f, 82f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(143f, 10.1f, 88f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(141f, 10.1f, 65f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(148f, 10.1f, 73f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(157f, 10.1f, 70f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(164f, 10.1f, 72f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(153f, 10.1f, 81f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(148f, 10.1f, 88f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(160f, 10.1f, 91f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(153f, 10.1f, 87f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(166f, 10.1f, 83f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(162f, 10.1f, 74f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(158f, 10.1f, 68f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(166f, 10.1f, 66f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(173f, 10.1f, 76f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(179f, 10.1f, 82f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(182f, 10.1f, 76f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(179f, 10.1f, 69f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(172f, 10.1f, 80f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(174f, 10.1f, 89f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(184f, 10.1f, 87f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(190f, 10.1f, 83f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(190f, 10.1f, 67f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(221f, 10.1f, 88f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(237f, 10.1f, 91f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(237f, 10.1f, 79f), Quaternion.identity);
        enemyPrefab = Instantiate(enemy, new Vector3(237f, 10.1f, 66f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
