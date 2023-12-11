using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escort : MonoBehaviour
{
    // Start is called before the first frame update

    MissionController mis;
    public GameObject Cont;
    private Animator IsEscorting;
    private Animator IsDone;
    private Animator Dead;
    public bool Moving;
    public bool Stopped;
    public bool IsDead;

    void Start()
    {
        
        mis = Cont.GetComponent<MissionController>();
        IsEscorting = GetComponent<Animator>();
        IsDone = GetComponent<Animator>();  
        Dead = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Moving = mis.escort;
        Stopped = mis.escortDone;
        IsDead = mis.boom;
        if (Stopped != true)
        {
            if (Moving == true)
            {
                IsEscorting.SetBool("IsWalking", true);
            }
            else
            {
                IsEscorting.SetBool("IsWalking", false);
            }
        }
        else if (Stopped == true)
        {
            IsEscorting.SetBool("IsWalking", false);
            IsDone.SetBool("IsDone", true);
        }

        if(IsDead == true)
        {
            IsEscorting.SetBool("IsWalking", false);
            IsDone.SetBool("IsDone", false);
            Dead.SetBool("IsDead", true);
        }
    }

}
