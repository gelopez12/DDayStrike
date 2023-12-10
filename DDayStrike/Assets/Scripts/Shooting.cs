using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 100f;
    private Animator animator;
    public AudioSource shoot;
    public AudioSource reloadPing;
    public AudioSource loadingClip;
    public float Mag = 10.0f;
    public ParticleSystem flashMu;

    private Renderer muzzleRenderer;
    private bool isFlickering = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        flashMu.Stop();
        muzzleRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        flashMu.Stop();
        if (Input.GetKeyDown(KeyCode.Mouse0) && Mag > 0)
        {
            Shoot();
            shoot.Play();
            Mag--;


            if (Mag == 0)
            {
                reloadPing.Play();
            }
        }
        
        if (Mag == 0 && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadCoroutine());
        }
        
    }
    IEnumerator Flicker(float duration)
    {
        float flickerStartTime = Time.time;

        while (Time.time - flickerStartTime < duration)
        {
            isFlickering = !isFlickering;

            // Toggle the visibility of the Renderer component
            if (muzzleRenderer != null)
            {
                muzzleRenderer.enabled = isFlickering;
            }

            yield return null;
        }

        // Ensure the Renderer is turned off after the flickering duration
        if (muzzleRenderer != null)
        {
            muzzleRenderer.enabled = false;
        }
    }

    IEnumerator ReloadCoroutine()
    {   
      
        loadingClip.Play();
        
        yield return new WaitForSeconds(2.5f);

        Mag = 10.0f;
    }

    void Shoot()
    {
        flashMu.Play();
        StartCoroutine(Flicker(0.1f));
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
