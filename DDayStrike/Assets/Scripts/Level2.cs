using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    PlayersHealth phScript;
    Shooting shootScript;
    public GameObject player;
    public Text HP;
    public Text ammunition;
    public Text reload;
    public int maxiHealth;
    public int health;
    public float ammo;

    public GameObject Keys;
    public GameObject Clipboard;
    public GameObject Radio;
    public GameObject AmmoBox;
    public GameObject Sol1;
    public GameObject Sol2;
    public GameObject Sol3;
    public GameObject Sol4;
    //public GameObject light;

    public TextMeshProUGUI keysText;
    public TextMeshProUGUI clipboardText;
    public TextMeshProUGUI radioText;
    public TextMeshProUGUI ammoBoxText;
    public TextMeshProUGUI solText;
    public TextMeshProUGUI FindExit;
    public int Count = 0;

    public GameObject finalObject; // The object that appears when all items are picked up
    public GameObject Prompt; // The object that appears and disappears

    private GameObject currentPickup;

    void Start()
    {
        phScript = player.GetComponent<PlayersHealth>();
        shootScript = player.GetComponent<Shooting>();
        FindExit.gameObject.SetActive(false);
    }

    void Update()
    {
        
        maxiHealth = phScript.maxHealth;
        health = phScript.currentHealth;
        HP.text = "HP: " + health + " / " + maxiHealth;

        ammo = shootScript.Mag;
        ammunition.text = "Ammo: " + ammo + " / 10";
        if (ammo == 0)
        {
            reload.text = "Press [R] to Reload";
        }
        else
        {
            reload.text = "";
        }

        if (Input.GetKeyDown(KeyCode.F) && currentPickup != null)
        {
            PickUpObject(currentPickup);
        }

        CheckForNearbyPickups();
        CheckForDestroyedSols(); // Check for destroyed Sol objects
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

    void CheckForDestroyedSols()
    {
        // Check if all Sol objects are destroyed or inactive
        if (Count == 4 && Sol1 == null && Sol2 == null && Sol3 == null && Sol4 == null)
        {
            // Update the Sol text color
            UpdateTextColor("Sol", Color.green);
            finalObject.SetActive(true);
            keysText.gameObject.SetActive(false);
            clipboardText.gameObject.SetActive(false);
            radioText.gameObject.SetActive(false);
            ammoBoxText.gameObject.SetActive(false);
            solText.gameObject.SetActive(false);
            FindExit.gameObject.SetActive(true);
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
            case "Sol": // Add this case for the Sol text
                return solText;
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
            
            Debug.Log("IT worked");
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            SceneManager.LoadScene("Level3");
        }
    }
}