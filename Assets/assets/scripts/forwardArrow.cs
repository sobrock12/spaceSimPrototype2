using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forwardArrow : MonoBehaviour
{

    public GameObject arrow;
    public GameObject ship;
    public shipController shipCont;

    void Awake()
    {
        
        shipCont = ship.GetComponent<shipController>();

    }

    // Update is called once per frame
    void Update()
    {

        if (shipCont.forwardThrust)
        {

            arrow.SetActive(true);

        }

        if (!shipCont.forwardThrust)
        {

            arrow.SetActive(false);

        }
        
    }
}
