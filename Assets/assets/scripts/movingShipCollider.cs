using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingShipCollider : MonoBehaviour
{

    public GameObject player;
    public GameObject lookDir;
    public GameObject planet;
    public float dist;


    // Update is called once per frame
    void FixedUpdate()
    {

        int layerMask = 1 << 9;

        //layerMask = ~layerMask;

        RaycastHit hit;

        Debug.DrawRay(player.transform.position, lookDir.transform.forward * dist, Color.white);

        if (Physics.Raycast(player.transform.position, lookDir.transform.forward, out hit, Mathf.Infinity, layerMask))
        {

            transform.position = hit.point;
            Debug.Log("did hit");

        }

    }
}
