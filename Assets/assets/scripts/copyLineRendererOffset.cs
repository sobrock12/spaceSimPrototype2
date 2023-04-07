using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyLineRendererOffset : MonoBehaviour
{

    public GameObject hand;

    public LineRenderer offset;

    public Vector3 lineOffsetPos;

    public Vector3 added;

    // Start is called before the first frame update
    void Start()
    {

        offset = hand.GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

        lineOffsetPos = offset.GetPosition(1);

        added = transform.localEulerAngles + lineOffsetPos;

        transform.localEulerAngles = added;
        
    }
}
