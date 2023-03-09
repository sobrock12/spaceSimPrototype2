using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inverseMovement : MonoBehaviour
{

    public GameObject player;
    public displayForwardVector inverseVar;
    public shipController shipController;
    public Vector3 inverseDir;
    public Vector3 finalRight;
    public Vector3 finalUp;
    public Rigidbody rb;
    public float leftRightStrafeAmount;
    public float upDownStrafeAmount;
    public float strafeSpeed;
    public bool backwardsThrust;
    public float backwardsSpeed = 1f;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        inverseVar = player.GetComponent<displayForwardVector>();
        shipController = player.GetComponent<shipController>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        inverseDir = inverseVar.inverseForward;
        finalRight = inverseVar.inverseRight;
        finalUp = inverseVar.inverseUp;

        strafeSpeed = shipController.strafeSpeed;

        leftRightStrafeAmount = shipController.leftRightStrafe * strafeSpeed;
        upDownStrafeAmount = shipController.upDownStrafe * strafeSpeed;

        backwardsThrust = shipController.backwardsThrust;

        if (backwardsThrust == true)
        {

            rb.AddForce(-inverseDir * backwardsSpeed, ForceMode.VelocityChange);

        }
        
        //Debug.Log(inverseDir);

        rb.AddForce(inverseDir * shipController.shipSpeed, ForceMode.VelocityChange);

        rb.AddForce(finalRight * leftRightStrafeAmount, ForceMode.VelocityChange);

        rb.AddForce(finalUp * upDownStrafeAmount, ForceMode.VelocityChange);

    }
}
