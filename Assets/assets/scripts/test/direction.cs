using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction : MonoBehaviour
{

    public Transform player;
    public Transform target;


    // Update is called once per frame
    void Update()
    {

        var heading = target.position - player.position;

        var distance = heading.magnitude;

        var direction = heading / distance;

        Debug.Log(direction);

        transform.position = heading;

    }
}
