using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropeler : MonoBehaviour
{
    public float rotationSpeed = 2000.0f;

    private void Start()
    {
    
    }
    void Update()
    {
        RotatePropeller();
    }
    void RotatePropeller()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
