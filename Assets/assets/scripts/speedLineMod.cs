using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticleSystem))]

public class speedLineMod : MonoBehaviour
{

    public GameObject ship;
    public shipController speedValues;
    private float shipSpeed;
    public float minSpeedCutoff = 1.5f;
    public ParticleSystem.MainModule main;
    public ParticleSystem.TrailModule trail;
    public int maxParts = 10;

    public float strafeMovementInputUpDown;
    public float strafeMovementInputLeftRight;

    public float turnMovementInputUpDown;
    public float turnMovementInputLeftRight;

    public Transform speedLineTarget;

    public float strafeMultiplier = 25f;
    public float turnMultiplier = 10f;

    public float lerpSpeed = 0.5f;

    public Vector3 targetPosition;

    private Vector3 velocity = Vector3.zero;



    void Start()
    {
        
        ParticleSystem ps = GetComponent<ParticleSystem>();
        main = ps.main;

        speedValues = ship.GetComponent<shipController>();

        trail = ps.trails;


    }

    // Update is called once per frame
    void Update()
    {



        shipSpeed = speedValues.shipSpeed;

        if (shipSpeed < minSpeedCutoff)
        {

            main.maxParticles = 0;

        }

        if (shipSpeed > minSpeedCutoff)
        {

            main.maxParticles = maxParts * (int)shipSpeed;

            main.simulationSpeed = shipSpeed/2;

            trail.widthOverTrail = 0.0005f * shipSpeed;

        }

        
        strafeMovementInputUpDown = speedValues.upDownStrafe * strafeMultiplier;
        strafeMovementInputLeftRight = speedValues.leftRightStrafe * strafeMultiplier;

        turnMovementInputUpDown = speedValues.upDown * turnMultiplier;
        turnMovementInputLeftRight = speedValues.leftRight * turnMultiplier;

        targetPosition = new Vector3(strafeMovementInputLeftRight + turnMovementInputLeftRight,
                                     strafeMovementInputUpDown + turnMovementInputUpDown,
                                     transform.localPosition.z);

        /*
        transform.localPosition = new Vector3(strafeMovementInputLeftRight + turnMovementInputLeftRight, 
                                                strafeMovementInputUpDown + turnMovementInputUpDown,
                                                transform.localPosition.z);
        */

        /*
        transform.localPosition = Vector3.Lerp(new Vector3(0f, 0f, transform.localPosition.z), 
                                                new Vector3(strafeMovementInputLeftRight + turnMovementInputLeftRight,
                                                            strafeMovementInputUpDown + turnMovementInputUpDown,
                                                             transform.localPosition.z),
                                                Time.deltaTime * lerpSpeed);

        */

        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPosition, ref velocity, lerpSpeed);

        transform.LookAt(speedLineTarget);
        
    }
}
