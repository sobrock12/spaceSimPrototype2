using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunLightPos : MonoBehaviour
{

    public GameObject start;
    public GameObject target;
    public float distance;
    public Vector3 pos;
    public float xOffset;
    public float yOffset;
    public float zOffset;


    // Update is called once per frame
    void Update()
    {

        pos = start.transform.position + ((target.transform.position - start.transform.position) / distance);

        pos = new Vector3((pos.x + xOffset), (pos.y + yOffset), (pos.z + zOffset));

        transform.position = pos;

        transform.LookAt(start.transform);
        
    }
}
