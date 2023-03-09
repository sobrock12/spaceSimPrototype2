using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpCheckRaycast : MonoBehaviour
{

    public RaycastHit hit;

    void Update()
    {

        Physics.Raycast(transform.position, transform.forward, out hit);

    }
}
