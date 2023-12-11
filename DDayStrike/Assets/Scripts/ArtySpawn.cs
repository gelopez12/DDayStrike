using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class ArtySpawn : MonoBehaviour
{
    public GameObject artilleryShellPrefab;
    public float minX = 15.0f;
    public float maxX = 55.0f;
    public float minZ = 20.0f;
    public float maxZ = 185.0f;
    public float shellFallSpeed = 10f;

    void Start()
    {
        // Start the continuous spawning coroutine
        StartCoroutine(SpawnArtilleryShellsContinuously());
    }

    IEnumerator SpawnArtilleryShellsContinuously()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(10.0f);

            // Spawn artillery shell
            SpawnArtilleryShell();
        }
    }

    void SpawnArtilleryShell()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minX, maxX),
            6.0f,
            Random.Range(minZ, maxZ)
        );

        GameObject artilleryShell = Instantiate(artilleryShellPrefab, randomPosition, Quaternion.identity);
        artilleryShell.GetComponent<Rigidbody>().AddForce(Vector3.down * shellFallSpeed);
    }
}
