using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneForward : MonoBehaviour
{
    public float speed = 5000f; // Adjust the speed as needed
    public float destroyDelay = 1000.0f; // Adjust the delay before destruction

    void Start()
    {
        // Invoke the DestroyObject method after the specified delay
        Invoke("DestroyObject", destroyDelay);
    }

    void Update()
    {
        // Move the object forward along its own z-axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void DestroyObject()
    {
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}
