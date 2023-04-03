using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpCheckRaycast : MonoBehaviour
{

    public RaycastHit hit;
    public LayerMask whatCanIHit;

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, whatCanIHit);

    }
}
