using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 10f, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, -90));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
