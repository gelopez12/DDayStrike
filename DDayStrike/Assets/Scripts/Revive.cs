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
        animator = GetComponent<Animator>();
         
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
    }
}
