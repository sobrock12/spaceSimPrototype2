using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class handRaycast : MonoBehaviour
{

    public GameObject hand;
    public LineRenderer lineOffset;
    public float distance = 10f;
    public TextMeshProUGUI textMesh;
    [SerializeField] private LayerMask WhatCanIHit = 11;
    public RaycastHit hit;


    void Start()
    {
        
        lineOffset = hand.GetComponent<LineRenderer>();
        //textMesh = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {

        //RaycastHit hit;

        Vector3 offset = lineOffset.GetPosition(1);

        Debug.DrawRay(transform.position, transform.TransformDirection(offset) * distance, Color.red);

        Physics.Raycast(transform.position, transform.TransformDirection(offset), out hit, distance, WhatCanIHit);


        
        if (hit.collider != null)
        {

            if (hit.collider.CompareTag("selectable"))
            {

                Debug.Log($"Found: {hit.collider.transform.name}");
                //textMesh.SetText(hit.collider.transform.name);

            }
            else
            {

                //textMesh.SetText("");

            }

        }

    }
}
