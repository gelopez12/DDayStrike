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
    private float Mag = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

    IEnumerator ReloadCoroutine()
    {       
        loadingClip.Play();
        
        yield return new WaitForSeconds(2.5f);

        Mag = 10.0f;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
