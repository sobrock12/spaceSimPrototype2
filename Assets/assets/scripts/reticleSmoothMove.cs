using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticleSmoothMove : MonoBehaviour
{

    public GameObject hand;
    public handRaycast handCast;

    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.085f;


    // Start is called before the first frame update
    void Start()
    {

        handCast = hand.GetComponent<handRaycast>();
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit = handCast.shootHit;

        transform.position = Vector3.SmoothDamp(transform.position, hit.point, ref velocity, smoothTime);
        
    }
}
