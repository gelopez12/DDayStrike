using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float minX = 0f;
    public float maxX = 118f;
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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
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
        if (collision.gameObject.name == "Revive Collider")
        {
            inReviveRing = true;
        } else
        {
            inReviveRing = false;
        }
    }

    public void Test(float a)
    {
        Debug.Log(a);
    }
}



