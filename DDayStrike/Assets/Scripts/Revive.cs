using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    MissionController pain;
    public GameObject DGuy;
    public bool Revived;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        pain = DGuy.GetComponent<MissionController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Revived = pain.escort;
        if(Revived == false)
        {
            animator.SetBool("IsUp", true);
        }
    }
}
