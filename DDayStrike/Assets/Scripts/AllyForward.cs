using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyForward : MonoBehaviour
{
    public float speed = 3.0f;
    public float minDuration = 4.0f;
    public float maxDuration = 10.0f;
    private Animator Running;
    private Animator Crouch;
    private Animator Death;

    private float moveTimer;

    void Start()
    {
        Running = GetComponent<Animator>();
        Crouch = GetComponent<Animator>();
        Death = GetComponent<Animator>();   
        ResetTimer();
    }

    void Update()
    {
        if (moveTimer > 0)
        {
            MoveForward();
            Running.SetBool("IsRun", true);
            moveTimer -= Time.deltaTime;
        }
        else
        {
            Running.SetBool("IsRun", false);
            Crouch.SetBool("IsCrouch", true);

            Debug.Log("Movement stopped after random duration.");
            Death.SetBool("IsDead", true);
            // Reset the timer for the next random duration.
            ResetTimer();
            Destroy(gameObject, 10.0f);
        }
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void ResetTimer()
    {
        // Set moveTimer to a random value between minDuration and maxDuration.
        moveTimer = Random.Range(minDuration, maxDuration);
    }
}