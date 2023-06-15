using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class handRaycast : MonoBehaviour
{

    public GameObject rightHand;
    public GameObject leftHand;
    public LineRenderer rightLineOffset;
    public LineRenderer leftLineOffset;
    public float distance = 10f;
    public float uiDistance = 100.0f;
    public float shootDistance = 100.0f;
    public float targetDist = 200.0f;
    public TextMeshProUGUI textMesh;

    [SerializeField] private LayerMask WhatCanIHit = 11;
    [SerializeField] private LayerMask aimingBorder;
    [SerializeField] private LayerMask whatCanIShoot;
    [SerializeField] private LayerMask enemy;

    public RaycastHit hit;

    public RaycastHit uiHit;

    public RaycastHit shootHit;

    public RaycastHit enemyUIBar;

    public bool rightTriggerFull = false;
    public bool leftTriggerFull = false;


    void Start()
    {
        
        rightLineOffset = rightHand.GetComponent<LineRenderer>();
        rightLineOffset.widthMultiplier = 0;
        leftLineOffset = leftHand.GetComponent<LineRenderer>();
        leftLineOffset.widthMultiplier = 0;


    }

    // Update is called once per frame
    void Update()
    {

        var rightHand = new List<UnityEngine.XR.InputDevice>();
        var leftHand = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHand);
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHand);


        //RaycastHit hit;

        Vector3 offset = rightLineOffset.GetPosition(1);
        Vector3 leftOffset = leftLineOffset.GetPosition(1);

        if (rightHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out var rightTrigger))
        {
            if (rightTrigger <= 0.001f)
            {

                //Debug.Log("right trigger not pulled");
                rightLineOffset.widthMultiplier = 0;
                rightTriggerFull = false;

            }

            if (rightTrigger < 0.75f && rightTrigger > 0.001f)
            {
                
                //Debug.Log("right trigger gently pulled");
                rightLineOffset.widthMultiplier = rightTrigger;
                rightTriggerFull = false;

            }

            if (rightTrigger > 0.751f)
            {

                //Debug.Log("right trigger fully pulled");
                rightLineOffset.widthMultiplier = rightTrigger;
                rightTriggerFull = true;

            }

        }

        if (leftHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out var leftTrigger))
        {

            if (leftTrigger <= 0.001f)
            {

                //Debug.Log("left trigger not pulled");
                leftLineOffset.widthMultiplier = 0;
                leftTriggerFull = false;

            }

            if (leftTrigger < 0.75f && leftTrigger > 0.001f)
            {

                //Debug.Log("left trigger gently pulled");
                leftLineOffset.widthMultiplier = leftTrigger;
                leftTriggerFull = false;

            }

            if (leftTrigger > 0.751f)
            {

                //Debug.Log("left trigger fully pulled");
                leftLineOffset.widthMultiplier = leftTrigger;
                leftTriggerFull = true;


            }

        }

        //Debug.DrawRay(transform.position, transform.TransformDirection(offset) * uiDistance, Color.red);

        Physics.Raycast(transform.position, transform.TransformDirection(offset), out hit, distance, WhatCanIHit);

        Physics.Raycast(transform.position, transform.TransformDirection(offset), out uiHit, uiDistance, aimingBorder);

        Physics.Raycast(transform.position, transform.TransformDirection(offset), out shootHit, shootDistance, whatCanIShoot);

        Physics.Raycast(transform.position, transform.TransformDirection(offset), out enemyUIBar, targetDist, enemy);


        if (hit.collider != null)
        {

            if (hit.collider.CompareTag("selectable"))
            {

                Debug.Log($"Found: {hit.collider.transform.name}");
                //textMesh.SetText(hit.collider.transform.name);

            }
            else
            {

                //textMesh.SetText("");

            }

        }

    }
}
