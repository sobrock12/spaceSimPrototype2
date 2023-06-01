using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedLimiter : MonoBehaviour
{

    public float currentSpeed;
    public float normalSpeedLimit = 25.0f;
    public float speedInCollider = 50.0f;

    public GameObject player;
    public shipController ship;

    public Collider shipCollider;

    void Awake()
    {
        StartCoroutine(wait());
        //player = GameObject.Find("ship1");
        //ship = player.GetComponent<shipController>();
        //shipCollider = player.GetComponent<BoxCollider>();

    }

    IEnumerator wait()
    {

        yield return new WaitForSeconds(1);

        player = GameObject.Find("ship1");
        ship = player.GetComponent<shipController>();
        shipCollider = player.GetComponent<BoxCollider>();


    }

    private void OnTriggerEnter(Collider shipCollider)
    {        
        
        ship.insideWarp = true;
        currentSpeed = speedInCollider;
        ship.shipSpeed = currentSpeed;
        ship.strafeSpeed = 30.0f;
        ship.rotateRate = 200.0f;
        ship.turnSpeed = 0.75f;

    }

    private void OnTriggerExit(Collider shipCollider)
    {

        ship.insideWarp = false;
        currentSpeed = normalSpeedLimit;
        ship.shipSpeed = currentSpeed;
        ship.strafeSpeed = 5f;
        ship.rotateRate = 125.0f;
        ship.turnSpeed = 0.20f;

    }


}
