using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipRotation : MonoBehaviour
{

    public GameObject steering;
    private Rigidbody rb;
    private float upDown;
    private float leftRight;
    public float speed = .1f;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }


    // Update is called once per frame
    void Update()
    {

        upDown = steering.transform.localRotation.x * speed;
        leftRight = steering.transform.localRotation.z * speed;

       rb.AddTorque(new Vector3(upDown, leftRight, 0.0f), ForceMode.Impulse);

    }
}
