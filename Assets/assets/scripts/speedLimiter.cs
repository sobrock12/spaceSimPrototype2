using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedLimiter : MonoBehaviour
{

    public float speedLimit = 10f;

    private void OnTriggerEnter(Collider other)
    {
        speedLimit = 3f;
    }

    private void OnTriggerExit(Collider other)
    {
        speedLimit = 10f;
    }


}
