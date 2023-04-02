using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCheckForInteraction : MonoBehaviour
{

   // public GameObject leftHand;
    public GameObject rightHand;
   // public handRaycast leftHandRaycast;
    public handRaycast rightHandRaycast;
    public Collider currentlySelectedRight;
    public Collider myCollider;
    public mapSpawner mapSpawner;
    public bool triggerIsPressed;
    public float triggerPressed;

    void Start()
    {

        //leftHandRaycast = leftHand.GetComponent<handRaycast>();
        rightHandRaycast = rightHand.GetComponent<handRaycast>();
        myCollider = GetComponent<BoxCollider>();
        mapSpawner = GetComponent<mapSpawner>();

    }

    // Update is called once per frame
    void Update()
    {

        //float triggerPressed;

        var rightHand = new List<UnityEngine.XR.InputDevice>();
        var leftHand = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHand);
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHand);

        rightHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out triggerPressed);

        if (triggerPressed <= 0.5f)
        {

            //Debug.Log("no longer pressed");
            triggerIsPressed = false;

        }

        if (triggerPressed > 0.5f)
        {

            //Debug.Log("pressed");
            triggerIsPressed = true;

        }


        currentlySelectedRight = rightHandRaycast.hit.collider;

        if (currentlySelectedRight == myCollider && triggerPressed > 0.5f)
        {

            mapSpawner.spawnMap();

        }
        
    }
}
