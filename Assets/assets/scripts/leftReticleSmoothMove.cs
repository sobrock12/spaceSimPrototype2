using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftReticleSmoothMove : MonoBehaviour
{

    public GameObject hand;
    public leftHandRaycast handCast;

    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.085f;

    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
        handCast = hand.GetComponent<leftHandRaycast>();

    }

    // Update is called once per frame
    void Update()
    {

        hit = handCast.leftUIHit;

        transform.position = Vector3.SmoothDamp(transform.position, hit.point, ref velocity, smoothTime);
        
    }
}
