using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    MissionController mis;
    public GameObject Cont;
    private ParticleSystem Explosion;
    public float Bomb;

    // Start is called before the first frame update
    void Start()
    {
        Explosion = GetComponent<ParticleSystem>();
        mis = Cont.GetComponent<MissionController>();
    }

    // Update is called once per frame
    void Update()
    {
        Bomb = mis.bangTime;
        if(Bomb > 30.0f)
        {
            Explosion.Play();
        }
    }
}
