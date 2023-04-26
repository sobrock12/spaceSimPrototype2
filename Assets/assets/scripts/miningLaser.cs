using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miningLaser : MonoBehaviour
{

    public bool press;
    public RaycastHit hit;
    public float distance = 100f;
    public float hitDist;
    public Vector3 hitVector;
    public float multiplier = 2.0f;
    public float startSpeed = 0.8f;
    public float slerpSpeed = 0.2f;
    public Vector3 startEnd;
    [SerializeField] private LayerMask mineable;
    public GameObject laser;

    // Update is called once per frame
    void Update()
    {


        distance = 100f;

        var rightHand = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHand);

        if (rightHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out press))
        {

            if (press == true)
            {

                Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mineable);
                hitDist = hit.distance;
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitDist, Color.red);

                hitDist = hitDist * multiplier;

                hitVector = new Vector3(2, 2, hitDist);

                startEnd = new Vector3(2, 2, 0);

                laser.transform.localScale = Vector3.Lerp(startEnd, hitVector, slerpSpeed);

            }

            if (press == false)
            {

                laser.transform.localScale = Vector3.Lerp(laser.transform.localScale, startEnd, slerpSpeed);

            }


        }


    }

}

