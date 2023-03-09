using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steeringMove : MonoBehaviour
{

    public GameObject ship;
    public shipController steering;
    public Vector3 steeringRotation;
    public float multiplier = 3f;

    void Start()
    {
        
        steering = ship.GetComponent<shipController>();

    }

    void Update()
    {

        transform.localEulerAngles = new Vector3(-steering.turn.x * multiplier, 0.0f, -steering.turn.y * multiplier);

    }
}
