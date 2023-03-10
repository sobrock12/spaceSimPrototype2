using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyTransform : MonoBehaviour
{
    public Transform shipObject;

    // Update is called once per frame
    void Update()
    {

        transform.position = shipObject.position;
        transform.rotation = shipObject.rotation;
        
    }
}
