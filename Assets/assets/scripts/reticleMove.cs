using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reticleMove : MonoBehaviour
{

    //public GameObject steering;
    private float upDown;
    private float leftRight;
    public float movementSpeed = 5f;
    RectTransform reticlePosition;


    // Start is called before the first frame update
    void Start()
    {

        reticlePosition = GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {

        var rightHand = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHand);

        Vector2 movementVector;
        if (rightHand[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out movementVector))
        {

            leftRight = movementVector.x / movementSpeed;
            upDown = movementVector.y / movementSpeed;

            reticlePosition.anchoredPosition3D = new Vector3(leftRight, upDown, 0.0f);


        }

        //upDown = steering.transform.localRotation.x / movementSpeed;
        //leftRight = steering.transform.localRotation.z / movementSpeed;


        //reticlePosition.anchoredPosition3D = new Vector3(-leftRight, -upDown, 0.0f);

    }
}
