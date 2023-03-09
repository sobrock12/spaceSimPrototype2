using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapZoomRotate : MonoBehaviour
{

    private float upDown;
    private float leftRight;
    public float rotSpeed = 2.0f;
    public float zoomSpeed = 4.0f;
    public GameObject mapZoomParent;
    public GameObject mapTestPrefab;
    public Vector3 newZ;
    public Vector3 newRot;

    // Update is called once per frame
    void Update()
    {

        var rightHand = new List<UnityEngine.XR.InputDevice>();
        var leftHand = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHand);
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHand);

        Vector2 rightVector;
        Vector2 leftVector;

        if (rightHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out rightVector))
        {

            leftRight = rightVector.x * rotSpeed;

            newRot = new Vector3(0, leftRight, 0);

            mapTestPrefab.transform.Rotate(newRot * Time.deltaTime);

        }

        if (leftHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out leftVector))
        {

            upDown = leftVector.y / zoomSpeed;

            newZ = new Vector3(0f, 0f, upDown);

            mapZoomParent.transform.localPosition += newZ;

        }

    }

}