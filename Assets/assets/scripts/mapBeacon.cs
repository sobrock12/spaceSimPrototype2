using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapBeacon : MonoBehaviour
{

    public Transform beacon;
    public float scale = 0f;
    public float max = 2.0f;
    public float speed = 0.75f;
    public bool increase = true;

    // Update is called once per frame
    void Update()
    {

        if (scale <= 0f)
        {

            increase = true;

        }

        if (scale >= max)
        {

            increase = false;

        }

        if (increase)
        {

            scale += speed * Time.deltaTime;

        }

        if (!increase)
        {

            scale -= speed * Time.deltaTime;

        }

        beacon.transform.localScale = new Vector3(scale, scale, scale);
        
    }
}
