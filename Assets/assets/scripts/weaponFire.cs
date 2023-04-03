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

    public GameObject leftReticle;
    public GameObject rightReticle;

    [SerializeField] private LayerMask WhatCanIHit = 12;

    public float distance = 75.0f;

    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.085f;

    public GameObject leftWeapon;
    public GameObject rightWeapon;

    public Transform referencePoint;

    public bool leftCanShoot = false;
    public bool rightCanShoot = false;

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

        RaycastHit leftHit = leftHandCast.shootHit;

        RaycastHit rightHit = rightHandCast.shootHit;

        if (rightHit.collider == null)
        {

            rightReticle.SetActive(false);
            rightWeapon.transform.LookAt(referencePoint);
            rightCanShoot = false;
        }

        if (leftHit.collider == null)
        {

            leftReticle.SetActive(false);
            leftWeapon.transform.LookAt(referencePoint);
            leftCanShoot = false;

        }

        if (rightHit.collider != null)
        {        
            
            rightWeapon.transform.LookAt(rightHit.point);

            rightReticle.SetActive(true);
            if (rightHit.collider.CompareTag("aimingBorder"))
            {

                Debug.Log($"found : {rightHit.collider.transform.name}");

            }

            if (rightHandCast.rightTriggerFull == true)
            {

                Debug.Log("shoot right");
                rightCanShoot = true;

            }

        }

        if (leftHit.collider != null)
        {        
            
            leftWeapon.transform.LookAt(leftHit.point);

            leftReticle.SetActive(true);
            if (leftHit.collider.CompareTag("aimingBorder"))
            {

                Debug.Log($"found : {leftHit.collider.transform.name}");

            }

            if (leftHandCast.leftTriggerFull == true)

            {

                Debug.Log("shoot left");
                leftCanShoot = true;

            }

        }

    }
}
