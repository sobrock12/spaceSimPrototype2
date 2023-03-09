using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class lookAtCamera : MonoBehaviour
{

    public Transform target;
    public Transform ship;

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(target, ship.up);

    }

}
