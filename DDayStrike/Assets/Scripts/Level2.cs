using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public GameObject Keys;
    public GameObject Clipboard;
    public GameObject Radio;
    public GameObject AmmoBox;

    private GameObject currentPickup; // To store the current pickup object

    // Update is called once per frame
    void Update()
    {
        // Check for object pickup input
        if (Input.GetKeyDown(KeyCode.F) && currentPickup != null)
        {
            PickUpObject(currentPickup);
        }
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is a pickup object
        if (other.CompareTag("Keys") || other.CompareTag("Clipboard") || other.CompareTag("Radio") || other.CompareTag("AmmoBox"))
        {
            currentPickup = other.gameObject;
            Debug.Log("Near pickup object: " + currentPickup.name);
        }
    }

    // OnTriggerExit is called when the Collider other has stopped touching the trigger
    void OnTriggerExit(Collider other)
    {
        // Check if the exited object is the current pickup object
        if (other.gameObject == currentPickup)
        {
            currentPickup = null;
            Debug.Log("Left pickup object");
        }
    }

    // Method to handle object pickup
    void PickUpObject(GameObject pickupObject)
    {
        // Implement your pickup logic here
        // For example, you can deactivate the pickup object
        pickupObject.SetActive(false);
        Debug.Log("Picked up: " + pickupObject.name);
    }
}
