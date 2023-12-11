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
    public bool Moving;
    public bool Stopped;

    void Start()
    {
        
         mis = Cont.GetComponent<MissionController>();
        IsEscorting = GetComponent<Animator>();
        IsDone = GetComponent<Animator>();  

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Moving = mis.escort;
        Stopped = mis.escortDone;
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
    }

}
