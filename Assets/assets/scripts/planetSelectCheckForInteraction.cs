using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetSelectCheckForInteraction : MonoBehaviour
{

    public GameObject rightHand;
    public handRaycast rightHandRaycast;
    public Collider currentlySelectedRight;

    public GameObject sun;
    public Collider sunCollider;
    public GameObject sunDotted;
    public GameObject sunSolid;
    public bool sunHasRun = false;

    public GameObject brokenPlanet;
    public Collider brokenCollider;
    public GameObject brokenDotted;
    public GameObject brokenSolid;
    public bool brokenHasRun = false;

    public GameObject ringedPlanet;
    public Collider ringedCollider;
    public GameObject ringedDotted;
    public GameObject ringedSolid;
    public bool ringedHasRun = false;

    public GameObject gasPlanet;
    public Collider gasCollider;
    public GameObject gasDotted;
    public GameObject gasSolid;
    public bool gasHasRun = false;

    public GameObject lavaPlanet;
    public Collider lavaCollider;
    public GameObject lavaDotted;
    public GameObject lavaSolid;
    public bool lavaHasRun = false;

    public bool triggerIsPressed;

    public bool selectionActive = false;

    // Start is called before the first frame update
    void Start()
    {

        rightHandRaycast = rightHand.GetComponent<handRaycast>();
        sunCollider = sun.GetComponent<BoxCollider>();
        brokenCollider = brokenPlanet.GetComponent<SphereCollider>();
        ringedCollider = ringedPlanet.GetComponent<SphereCollider>();
        gasCollider = gasPlanet.GetComponent<SphereCollider>();
        lavaCollider = lavaPlanet.GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {

        float triggerPressed;

        var rightHand = new List<UnityEngine.XR.InputDevice>();
        var leftHand = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHand);
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHand);

        rightHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out triggerPressed);

        if (triggerPressed <= 0.001f)
        {

            //Debug.Log("no longer pressed");
            triggerIsPressed = false;

        }

        if (triggerPressed > 0.001f)
        {

            //Debug.Log("pressed");
            triggerIsPressed = true;


        }

        currentlySelectedRight = rightHandRaycast.hit.collider;

        Debug.Log(currentlySelectedRight);

        if (currentlySelectedRight == sunCollider)
        {

            Debug.Log("sun selected");
            sunDotted.SetActive(true);

            if (!sunHasRun && triggerIsPressed)
            {

                sunSolid.SetActive(!sunSolid.activeSelf);
                sunHasRun = true;

            }

            if (sunHasRun && !triggerIsPressed)
            {

                sunHasRun = false;

            }

        }

        if (currentlySelectedRight == brokenCollider)
        {

            Debug.Log("broken planet selected");
            brokenDotted.SetActive(true);

            if (!brokenHasRun && triggerIsPressed)
            {

                brokenSolid.SetActive(!brokenSolid.activeSelf);
                brokenHasRun = true;

            }

            if (brokenHasRun && !triggerIsPressed)
            {

                brokenHasRun = false;

            }


        }

        if (currentlySelectedRight == ringedCollider)
        {

            Debug.Log("ringed planet selected");
            ringedDotted.SetActive(true);

            if (!ringedHasRun && triggerIsPressed)
            {

                ringedSolid.SetActive(!ringedSolid.activeSelf);
                ringedHasRun = true;

            }

            if (ringedHasRun && !triggerIsPressed)
            {

                ringedHasRun = false;

            }


        }

        if (currentlySelectedRight == gasCollider)
        {

            Debug.Log("gas giant selected");
            gasDotted.SetActive(true);

            if (!gasHasRun && triggerIsPressed)
            {

                gasSolid.SetActive(!gasSolid.activeSelf);
                gasHasRun = true;

            }

            if (gasHasRun && !triggerIsPressed)
            {

                gasHasRun = false;

            }


        }

        if (currentlySelectedRight == lavaCollider)
        {

            Debug.Log("lava planet selected");
            lavaDotted.SetActive(true);

            if (!lavaHasRun && triggerIsPressed)
            {

                lavaSolid.SetActive(!lavaSolid.activeSelf);
                lavaHasRun = true;

            }

            if (lavaHasRun && !triggerIsPressed)
            {

                lavaHasRun = false;

            }

        }

        if (currentlySelectedRight != sunCollider && currentlySelectedRight != brokenCollider &&
            currentlySelectedRight != ringedCollider && currentlySelectedRight != gasCollider &&
            currentlySelectedRight != lavaCollider)
        {

            Debug.Log("no planet selected");
            sunDotted.SetActive(false);
            brokenDotted.SetActive(false);
            ringedDotted.SetActive(false);
            gasDotted.SetActive(false);
            lavaDotted.SetActive(false);

        }

    }

}
