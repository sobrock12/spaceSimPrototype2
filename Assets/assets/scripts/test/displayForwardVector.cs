using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayForwardVector : MonoBehaviour
{

    public Vector3 forwardDir;
    public Vector3 inverseForward;
    public Vector3 rightDir;
    public Vector3 inverseRight;
    public Vector3 upDir;
    public Vector3 inverseUp;

    // Update is called once per frame
    void Update()
    {

        forwardDir = transform.forward;
        inverseForward = -transform.forward;

        rightDir = transform.right;
        inverseRight = -transform.right;

        upDir = transform.up;
        inverseUp = -transform.up;


        //Debug.Log(forwardDir);
        //Debug.Log(inverseForward);

    }
}
