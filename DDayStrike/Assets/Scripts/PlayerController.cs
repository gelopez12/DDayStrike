using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MissionController mcScript;
    public GameObject mc;
    public float minX = 0f;
    public float maxX = 135f;
    public float minZ = 28f;
    public float maxZ = 172f;
    public float speed = 10.0f;
    public float bulletSpeed = 50.0f;
    public float turnSpeed = 500.0f;
    public float angle;
    public float horizontalInput;
    public bool horizontalInputBool;
    public float verticalInput;
    public bool verticalInputBool;
    public GameObject bulletPrefab;
    private Animator animator;
    public bool inReviveRing;
    public bool inAmbushRing;
    public bool inRetrieveRing;
    public bool inDropRing;
    public bool inEscortRing;
    public float defendTime;
    public bool doorTouch;
    public bool landmineTouch;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("");
        animator = GetComponent<Animator>();
        mcScript = mc.GetComponent<MissionController>();
    }

    // Update is called once per frame

    void Update()
    {
        //defendTime = mcScript.bangTime;

        // Get movement key inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Checking if movement keys are pressed
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            verticalInputBool = true;
        }
        else
        {
            verticalInputBool = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            horizontalInputBool = true;
        }
        else
        {
            horizontalInputBool = false;
        }

        // Calculate movement based on arrow keys
        Vector3 arrowKeyMovement = new Vector3(verticalInput, 0, -horizontalInput) * speed * Time.deltaTime;

        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));

        // Calculate the direction from the player to the mouse cursor
        Vector3 direction = mousePosition - transform.position;
        direction.y = 0;

        // Move the player towards the mouse cursor only when arrow keys are pressed
        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.position += arrowKeyMovement;
        }
       

        // Clamp the position to stay within bounds
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedZ = Mathf.Clamp(transform.position.z, minZ, maxZ);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

        // Rotate the player to face the mouse cursor
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }


    }
    void FixedUpdate()
    {
        float movementSpeed = new Vector2(horizontalInput, verticalInput).sqrMagnitude;

        if (movementSpeed > 0.1f)  // Adjust the threshold as needed
        {
            animator.SetBool("IsWalking", true);
            //animator.SetFloat("Speed", movementSpeed);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        //"Revive"
        if (collision.gameObject.name == "Revive Collider" || collision.gameObject.name == "Down Player(Clone)")
        {
            inReviveRing = true;
        } else
        {
            inReviveRing = false;
        }

        //"Ambush"
        if (collision.gameObject.name == "Ambush Collider")
        {
            inAmbushRing = true;
        } else
        {
            inAmbushRing = false;
        }

        //"Retrieve"
        if (collision.gameObject.name == "Retrieve Collider" || collision.gameObject.name == "Retrieve Object(Clone)")
        {
            inRetrieveRing = true;
        } else
        {
            inRetrieveRing = false;
        }
        if (collision.gameObject.name == "Drop Collider")
        {
            inDropRing = true;
        } else
        {
            inDropRing = false;
        }

        //Door
        if (collision.gameObject.name == "Bunker Door(Clone)")
        {
            doorTouch = true;
        } else
        {
            doorTouch = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //"Escort/Bangalore"
        if (collision.gameObject.name == "Escort Collider" || collision.gameObject.name == "To Escort(Clone)")
        {
            defendTime = mcScript.bangTime;
            if (defendTime < 30f)
            {
                inEscortRing = true;
            }
        } else
        {
            inEscortRing = false;
        }

        if (collision.gameObject.name == "Landmine(Clone)")
        {
            landmineTouch = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        //"Escort/Bangalore"
        if (collision.gameObject.name == "Escort Collider")
        {
            inEscortRing = false;
        }
    }

    public void Test(float a)
    {
        Debug.Log(a);
    }
}



