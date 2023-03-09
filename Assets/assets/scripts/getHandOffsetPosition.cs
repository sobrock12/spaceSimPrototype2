using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHandOffsetPosition : MonoBehaviour
{

    public GameObject hand;
    public LineRenderer lineOffset;


    // Start is called before the first frame update
    void Start()
    {

        lineOffset = hand.GetComponent<LineRenderer>();
        transform.position = lineOffset.GetPosition(1);


    }

}
