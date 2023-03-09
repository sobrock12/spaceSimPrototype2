using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtLargeBody : MonoBehaviour
{

    public GameObject largeBody;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(largeBody.transform);
    }
}
