using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class strafeReticleMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float upDown;
    private float leftRight;
    public float positionLimit = 0.035f;
    RectTransform reticlePosition;
    public Image strafeReticle;
    public Vector2 movementVector;


    // Start is called before the first frame update
    void Start()
    {

        reticlePosition = GetComponent<RectTransform>();
        strafeReticle = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

        var leftHand = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHand);

        //Vector2 movementVector;
        if (leftHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out movementVector))
        {

            leftRight = movementVector.x * positionLimit;
            upDown = movementVector.y * positionLimit;

            reticlePosition.anchoredPosition3D = new Vector3(leftRight, upDown, 0.0f);

        }
    }
}
