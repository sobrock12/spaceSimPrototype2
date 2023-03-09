using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class warpCheckForInteraction : MonoBehaviour
{

    public GameObject ship;
    public warpCheckRaycast ray;
    public TextMeshProUGUI warpText;
    public Collider currentlyAligned;
    public GameObject warpButton;
    public Collider warpButtonCollider;
    public mapCheckForInteraction rightHand;

    public GameObject sun;
    public Collider sunCollider;
    public GameObject sunActive;

    public GameObject terra;
    public Collider terraCollider;
    public GameObject terraActive;

    public GameObject gas;
    public Collider gasCollider;
    public GameObject gasActive;

    public GameObject ringed;
    public Collider ringedCollider;
    public GameObject ringedActive;

    public GameObject lava;
    public Collider lavaCollider;
    public GameObject lavaActive;

    public bool canWarp = false;


    void Start()
    {

        ray = ship.GetComponent<warpCheckRaycast>();
        sunCollider = sun.GetComponent<SphereCollider>();
        terraCollider = terra.GetComponent<SphereCollider>();
        gasCollider = gas.GetComponent<SphereCollider>();
        ringedCollider = ringed.GetComponent<SphereCollider>();
        lavaCollider = lava.GetComponent<SphereCollider>();
        warpButtonCollider = warpButton.GetComponent<BoxCollider>();

        warpButtonCollider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        currentlyAligned = ray.hit.collider;

        if (currentlyAligned == sunCollider && sunActive.activeInHierarchy)
        {

            canWarp = true;

        }

        if (currentlyAligned == terraCollider && terraActive.activeInHierarchy)
        {

            canWarp = true;

        }

        if (currentlyAligned == gasCollider && gasActive.activeInHierarchy)
        {

            canWarp = true;

        }

        if (currentlyAligned == ringedCollider && ringedActive.activeInHierarchy)
        {

            canWarp = true;

        }

        if (currentlyAligned == lavaCollider && lavaActive.activeInHierarchy)
        {

            canWarp = true;

        }

        if (currentlyAligned != sunCollider && currentlyAligned != terraCollider && 
            currentlyAligned != gasCollider && currentlyAligned != ringedCollider && currentlyAligned != lavaCollider)
        {
        
            canWarp = false;
        
        }

        if (canWarp)
        {

            warpText.color = Color.white;
            warpButtonCollider.enabled = true;


        }
        else
        {

            warpText.color = Color.grey;
            warpButtonCollider.enabled = false;

        }

        if (rightHand.currentlySelectedRight == warpButtonCollider && rightHand.triggerPressed > 0.001f)
        {

            startWarp();

        }


    }

    void startWarp()
    {

        Debug.Log("warp triggered");

    }
}
