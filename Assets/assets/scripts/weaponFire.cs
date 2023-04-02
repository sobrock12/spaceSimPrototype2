using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponFire : MonoBehaviour
{
    public GameObject ship;

    public GameObject leftHand;
    public GameObject rightHand;

    public LineRenderer leftLineOffset;
    public LineRenderer rightLineOffset;

    public float offset;

    public handRaycast leftHandCast;
    public handRaycast rightHandCast;

    [SerializeField] private LayerMask WhatCanIHit = 12;

    public float distance = 75.0f;

    void Start()
    {
        
        leftHandCast = leftHand.GetComponent<handRaycast>();
        rightHandCast = rightHand.GetComponent<handRaycast>();

        leftLineOffset = leftHand.GetComponent<LineRenderer>();
        rightLineOffset = rightHand.GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 rightOffset = rightLineOffset.GetPosition(1);

        //Vector3 leftOffset = leftLineOffset.GetPosition(1);

        RaycastHit leftHit = leftHandCast.shootHit;

        RaycastHit rightHit = rightHandCast.shootHit;

        if (rightHit.collider != null)
        {

            if (rightHit.collider.CompareTag("aimingBorder"))
            {

                Debug.Log($"found : {rightHit.collider.transform.name}");

            }

            if (rightHandCast.rightTriggerFull == true)
            {

                Debug.Log("shoot right");

            }

        }

        if (leftHit.collider != null)
        {

            if (leftHit.collider.CompareTag("aimingBorder"))
            {

                Debug.Log($"found : {leftHit.collider.transform.name}");

            }

            if (leftHandCast.leftTriggerFull == true)

            {

                Debug.Log("shoot left");

            }

        }



    }
}
