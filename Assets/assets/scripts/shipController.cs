using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour
{

    //public GameObject speedLimitColliderObject;
    //public speedLimiter speedLimitCollider;
    private Rigidbody rb;
    public float upDown;
    public float leftRight;
    public float turnSpeed = 7.5f;
    public Vector3 turn;
    public float rotateRate = 2.0f;
    public bool addSpeed;
    public bool subSpeed;
    public float shipSpeed;
    public float speedRate = 0.1f;
    public float maxSpeed = 25.0f;
    public float leftRightStrafe;
    public float upDownStrafe;
    public float strafeSpeed = 0.1f;
    public Vector3 strafe;
    public bool backwardsThrust;
    public bool canThrust;
    public bool backThrust;
    public bool forwardThrust;
    public warpCheckForInteraction warpActive;
    public bool insideWarp = false;
    public GameObject warpButton;
    public statusVars stats;


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        //speedLimitCollider = speedLimitColliderObject.GetComponent<speedLimiter>();
        warpActive = warpButton.GetComponent<warpCheckForInteraction>();
        stats = GetComponent<statusVars>();

    }

    void FixedUpdate()
    {
        //maxSpeed = speedLimitCollider.speedLimit;

        var rightHand = new List<UnityEngine.XR.InputDevice>();
        var leftHand = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHand);
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHand);


        Vector2 turnMovementVector;
        Vector2 strafeMovementVector;
        float rotateRight;
        float rotateLeft;
        /*
        if (warpActive.warpHasRun && insideWarp)
        {

            maxSpeed = 1000.0f;

        }

        if (!insideWarp)
        {

            maxSpeed = 25.0f;
            if (shipSpeed > 25.0f)
            {

                shipSpeed = 25.0f;

            }

        }

        if (!warpActive.warpHasRun)
        {

            maxSpeed = 25.0f;
            insideWarp = false;

            if (shipSpeed > 25.0f)
            {

                shipSpeed = 25.0f;

            }

        }*/

        if (rightHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out turnMovementVector))
        {

            leftRight = turnMovementVector.x / turnSpeed;
            upDown = turnMovementVector.y / turnSpeed;

            turn = new Vector3(-upDown, leftRight, 0.0f);

            rb.AddRelativeTorque(turn, ForceMode.Impulse);

        }

        if (rightHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.grip, out rotateRight))
        {

                rb.AddRelativeTorque(0.0f, 0.0f, -rotateRight * rotateRate, ForceMode.Force);

        }

        if (leftHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.grip, out rotateLeft))
        {
            
                rb.AddRelativeTorque(0.0f, 0.0f, rotateLeft * rotateRate, ForceMode.Force);
            
        }

        if (leftHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out addSpeed))
        {
            if (addSpeed)
            {

                shipSpeed += speedRate;
                shipSpeed = Mathf.Clamp(shipSpeed, 0f, maxSpeed);

            }
        }

        if (leftHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out subSpeed))
        {
            if (subSpeed)
            {

                shipSpeed -= speedRate;
                shipSpeed = Mathf.Clamp(shipSpeed, 0f, maxSpeed);

            }

            if (shipSpeed == 0f)
            {

                canThrust = true;
                //backwardsThrust = true;

            }

            if (shipSpeed > 0f)
            {

                canThrust = false;
                backwardsThrust = false;

            }

        }

        if (leftHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out strafeMovementVector))
        {

            leftRightStrafe = strafeMovementVector.x;
            upDownStrafe = strafeMovementVector.y;

            strafe = new Vector3(-leftRightStrafe, upDownStrafe, 0.0f);

        }

        if (rightHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out backThrust))
        {

            if (canThrust && backThrust)
            {

                backwardsThrust = true;

            }

            if (!backThrust || !canThrust)
            {

                backwardsThrust = false;

            }

        }

        if (leftHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out forwardThrust))
        {

            if (canThrust && forwardThrust)
            {

                forwardThrust = true;

            }

            if (!forwardThrust || !canThrust)
            {

                forwardThrust = false;

            }

        }

        if (shipSpeed > 0.0f)
        {

            stats.subFuel(shipSpeed / 1000.0f);

        }

    }
}
