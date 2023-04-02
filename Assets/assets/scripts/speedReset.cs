using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedReset : MonoBehaviour
{

    public GameObject player;
    public shipController ship;

    private void OnTriggerEnter(Collider other)
    {

        ship.shipSpeed = 25.0f;
        ship.strafeSpeed = 1.5f;

    }

}
