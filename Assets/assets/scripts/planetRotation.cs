using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetRotation : MonoBehaviour
{

    public float planetRotationSpeed = -0.0025f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0.0f, planetRotationSpeed, 0.0f, Space.Self);
        
    }
}
