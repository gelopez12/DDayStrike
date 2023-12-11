using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    MissionController pain;
    MissionController anotherpain;
    public GameObject DGuy;
    public GameObject Guy;
    public bool Revived;
    private Animator animator;
    private Animator Escort;
    public bool Moving;

    // Start is called before the first frame update
    void Start()
    {
        pain = DGuy.GetComponent<MissionController>();
        anotherpain = Guy.GetComponent<MissionController>();
        animator = GetComponent<Animator>();
        Escort = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        Revived = pain.reviveDone;
        Moving = anotherpain.escort;
        if(Revived == false)
        {
            animator.SetBool("IsUp", true);
        }

        if(Moving == true)
        {
            Escort.SetBool("IsWalking", true);
        }
        else
        {
            Escort.SetBool("IsWalking", false);
        }
    }
}
