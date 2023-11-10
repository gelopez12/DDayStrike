using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float bulletSpeed = 50.0f;
    public float turnSpeed = 500.0f;
    public float angle;
    public float horizontalInput;
    public float verticalInput;
    public GameObject bulletPrefab;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        

        transform.position -= (Vector3.forward * Time.deltaTime * speed * horizontalInput);
        transform.position += (Vector3.right * Time.deltaTime * speed * verticalInput);


        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        Vector3 direction = mousePosition - transform.position;
        direction.y = 0;
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

    
}
