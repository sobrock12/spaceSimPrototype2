using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class resetRotation : MonoBehaviour
{
    public GameObject steering;

    private Quaternion zero = Quaternion.Euler(0f, 0f, 0f);

    public void resetSteeringRotation()
    {

        steering.transform.rotation = zero;

    }

}
