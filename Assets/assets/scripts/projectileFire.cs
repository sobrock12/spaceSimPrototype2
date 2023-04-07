using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileFire : MonoBehaviour
{

    public float speed = 20.0f;
    public Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        
    }
}
