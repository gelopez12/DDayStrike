using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyForward : MonoBehaviour
{
    public float speed = 3.0f;
    private Animator Running;
    private Animator Crouch;
    private Animator Death;
    public ParticleSystem flash;

    private float moveTimer = 10.0f; // Adjusted to 10 seconds
    private float crouchTimer = 3.0f; // New timer for crouch animation

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

            // Check if it's time to crouch
            if (crouchTimer > 0 && moveTimer <= (10.0f - crouchTimer))
            {
                StartCoroutine(PlayFlashEffectDelayed(1.0f));
                Crouch.SetBool("IsCrouch", true);
                crouchTimer = 0; // To make sure crouch animation is only triggered once
            }
        }
        else
        {
            // Delay the death animation by 2 seconds
            if (moveTimer <= 8.0f)
            {
                Death.SetBool("IsDead", true);
            }

            Running.SetBool("IsRun", false);
            Debug.Log("Movement stopped after 10 seconds.");
            Destroy(gameObject, 10.0f);
        }
    }

    void MoveForward()
    {
        // Your move forward logic
        // transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Running.SetBool("IsRun", true);
    }

    IEnumerator PlayFlashEffectDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        flash.Play();
    }
}