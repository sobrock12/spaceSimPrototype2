using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throttleMove : MonoBehaviour
{

    public GameObject ship;
    public shipController throttle;
    public float startingPos;
    public float modifier = 0.03f;


    void Start()
    {
        
        throttle = ship.GetComponent<shipController>();
        startingPos = transform.localPosition.z;

    }

    void Update()
    {

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, startingPos + throttle.shipSpeed * modifier);

    }
}
