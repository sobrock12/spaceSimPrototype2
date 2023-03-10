using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class warpCheckForInteraction : MonoBehaviour
{

    public GameObject ship;
    public warpCheckRaycast ray;
    public TextMeshProUGUI warpText;
    public GameObject cancelText;
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

    public GameObject warpTunnel;
    public Transform warpParent;
    public Transform warpTunnelStart;
    public bool warpHasRun = false;
    public bool warpCanRun = true;
    public bool warpCanCancel = false;
    //public bool warpActive = false;

    public Transform shipWarpOrigin;

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

        if (warpHasRun)
        {

            warpButtonCollider.enabled = true;

        }

        if (rightHand.currentlySelectedRight == warpButtonCollider && rightHand.triggerPressed > 0.001f && !warpHasRun && warpCanRun)
        {

            startWarp();
            warpHasRun = true;
            warpCanRun = false;

        }

        if (warpHasRun)
        {

            cancelText.SetActive(true);

        }

        if (warpHasRun && rightHand.triggerPressed <= 0.001f)
        {

            warpCanCancel = true;

        }

        if (rightHand.currentlySelectedRight == warpButtonCollider && rightHand.triggerPressed > 0.001f && warpHasRun && warpCanCancel)
        {

            cancelWarp();
            warpHasRun = false;

        }

        if (!warpHasRun)
        {

            cancelText.SetActive(false);

        }

        if (!warpHasRun && rightHand.triggerPressed <= 0.001f)
        {

            warpCanRun = true;
            warpCanCancel = false;

        }
        

    }

    void startWarp()
    {

        Debug.Log("warp triggered");
        Instantiate(warpTunnel, shipWarpOrigin.position, shipWarpOrigin.rotation);

    }

    void cancelWarp()
    {

        Debug.Log("warp canceled");
        GameObject[] warpTunnels = GameObject.FindGameObjectsWithTag("tunnelSpawn");

        foreach (GameObject warpTunnel in warpTunnels)
        {

            Destroy(warpTunnel);

        }

    }

}
