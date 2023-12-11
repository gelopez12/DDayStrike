using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class ArtySpawn : MonoBehaviour
{
    public GameObject artilleryShellPrefab;
    public float minX = 5f;
    public float maxX = 60f;
    public float minZ = 10f;
    public float maxZ = 193f;
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
            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);

            // Spawn artillery shell
            SpawnArtilleryShell();
        }
    }

    void SpawnArtilleryShell()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minX, maxX),
            5.0f,
            Random.Range(minZ, maxZ)
        );

        GameObject artilleryShell = Instantiate(artilleryShellPrefab, randomPosition, Quaternion.identity);
        artilleryShell.GetComponent<Rigidbody>().AddForce(Vector3.down * shellFallSpeed);
    }
}
