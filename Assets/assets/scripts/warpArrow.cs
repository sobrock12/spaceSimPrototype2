using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpArrow : MonoBehaviour
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

        if (shipCont.shipSpeed > 25.0f)
        {

            arrow.SetActive(true);

        }

        if (shipCont.shipSpeed <= 25.0f)
        {

            arrow.SetActive(false);

        }
        
    }
}
