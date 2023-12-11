using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyForward : MonoBehaviour
{
    public float speed = 3.0f;
    private Animator Running;
    private Animator Crouch;
    private Animator Death;

    private float moveTimer = 10.0f; // Adjusted to 3 seconds

    void Start()
    {
        Running = GetComponent<Animator>();
        Crouch = GetComponent<Animator>();
        Death = GetComponent<Animator>();
    }

    void Update()
    {
        if (moveTimer > 0)
        {
            MoveForward();
            
            moveTimer -= Time.deltaTime;
        }
        else
        {
            
            Crouch.SetBool("IsCrouch", true);
            Running.SetBool("IsRun", false);
            Debug.Log("Movement stopped after 3 seconds."); // Corrected debug log
            Death.SetBool("IsDead", true);
            Destroy(gameObject, 10.0f);
        }
    }

    void MoveForward()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Running.SetBool("IsRun", true);
    }
}