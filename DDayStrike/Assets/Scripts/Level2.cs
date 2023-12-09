using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public GameObject Keys;
    public GameObject Clipboard;
    public GameObject Radio;
    public GameObject AmmoBox;  

    public TextMeshProUGUI keysText;
    public TextMeshProUGUI clipboardText;
    public TextMeshProUGUI radioText;
    public TextMeshProUGUI ammoBoxText;
    public int Count = 0; 

    public GameObject finalObject; // The object that appears when all items are picked up
    public GameObject Prompt; // The object that appears and disappears

    private GameObject currentPickup;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentPickup != null)
        {
            PickUpObject(currentPickup);
        }

        CheckForNearbyPickups();
    }

    void CheckForNearbyPickups()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Keys") || collider.CompareTag("Clipboard") || collider.CompareTag("Radio") || collider.CompareTag("AmmoBox"))
            {
                // Show the prompt when nearby the item
                Prompt.SetActive(true);

                currentPickup = collider.gameObject;
                break;
            }
            else
            {
                // Hide the prompt when not near any item
                Prompt.SetActive(false);
                currentPickup = null;
            }
        }
        
    }

    void PickUpObject(GameObject pickupObject)
    {
        if (pickupObject.activeSelf) // Check if the object is still active (not picked up)
        {
            Count++;
            pickupObject.SetActive(false);
            Debug.Log("Picked up: " + pickupObject.name);

            // Hide the prompt after picking up the item
            Prompt.SetActive(false);

            // Update the TextMeshPro color when picking up an item
            UpdateTextColor(pickupObject.tag, Color.green);

            // Check if all items are picked up
            CheckForCompletion();
        }
        
    }

    void UpdateTextColor(string tag, Color color)
    {
        TextMeshProUGUI textMeshPro = GetTextMeshProByTag(tag);

        if (textMeshPro != null)
        {
            textMeshPro.color = color;
        }
    }

    TextMeshProUGUI GetTextMeshProByTag(string tag)
    {
        switch (tag)
        {
            case "Keys":
                return keysText;
            case "Clipboard":
                return clipboardText;
            case "Radio":
                return radioText;
            case "AmmoBox":
                return ammoBoxText;
            default:
                return null;
        }
    }

    void CheckForCompletion()
    {
        // Check if all items are picked up
        if (Count == 4)
        {
           // ActivateFinalObject();
            finalObject.SetActive(true);
            Debug.Log("IT worked");
        }
    }

    /*void ActivateFinalObject()
    {
        if (!finalObject.activeSelf) 
        { 
            
            Debug.Log("Final object activated!");       
        }*/
}