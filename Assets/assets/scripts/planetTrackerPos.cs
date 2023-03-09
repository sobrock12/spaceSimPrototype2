using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetTrackerPos : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject planetBeingTracked;
    public float distanceBetweenPlanets;
    public float distance;
    public Vector3 pos;
    public float xOffset;
    public float yOffset;
    public float zOffset;

    void Update()
    {

        pos = playerCamera.transform.position + ((planetBeingTracked.transform.position - playerCamera.transform.position) / distance);

        pos = new Vector3((pos.x + xOffset), (pos.y + yOffset), (pos.z + zOffset));

        transform.position = pos;


    }
}
