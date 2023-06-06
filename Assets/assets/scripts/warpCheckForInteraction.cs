using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.VisualScripting;
using System;

public class warpCheckForInteraction : MonoBehaviour
{

    public GameObject player;
    public GameObject ship;
    public warpCheckRaycast ray;
    public TextMeshProUGUI warpText;
    public GameObject cancelText;
    public Collider currentlyAligned;
    public GameObject warpButton;
    public Collider warpButtonCollider;
    public mapCheckForInteraction rightHand;
    public Transform targetedDest;

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

    public Transform shipWarpOrigin;
    public Transform shipWarpOriginReset;

    public List <GameObject> tunnelsSpawned = new List<GameObject>();

    public Transform lastAdded;

    public float totalDistance;
    public float sqDist;
    public int numOfTunnels;
    public float tunnelLimit = 0.95f;


    public shipController shipCont;

    public GameObject shield;

    void Start()
    {

        ray = ship.GetComponent<warpCheckRaycast>();
        shipCont = player.GetComponent<shipController>();
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

        if (rightHand.currentlySelectedRight == warpButtonCollider && rightHand.triggerPressed > 0.5f && !warpHasRun && warpCanRun)
        {
            shipWarpOrigin = shipWarpOriginReset;
            startWarp();
            warpHasRun = true;
            warpCanRun = false;
            targetedDest = ray.transform;

        }

        if (warpHasRun)
        {

            cancelText.SetActive(true);

            /*
            currentDistance = ((targetedDest.position.x * targetedDest.position.x) +
                                (targetedDest.position.y * targetedDest.position.y) +
                                (targetedDest.position.z * targetedDest.position.z));

            currentSqDist = Mathf.Sqrt(currentDistance);

            currentlyAlignedTunnel = (int)Mathf.Ceil((currentSqDist / 2000f) * tunnelLimit);

            tunnelToSelect = (tunnelsSpawned.Count - currentlyAlignedTunnel);

            tunnelForSpeed = tunnelsSpawned[tunnelToSelect];
            */

        }

        if (warpHasRun && rightHand.triggerPressed <= 0.5f)
        {

            warpCanCancel = true;

        }

        if (rightHand.currentlySelectedRight == warpButtonCollider && rightHand.triggerPressed > 0.5f && warpHasRun && warpCanCancel)
        {

            cancelWarp();
            speedReset();
            warpHasRun = false;

        }

        if (!warpHasRun)
        {

            cancelText.SetActive(false);

        }

        if (!warpHasRun && rightHand.triggerPressed <= 0.5f)
        {

            warpCanRun = true;
            warpCanCancel = false;

        }        

    }

    void startWarp()
    {

        totalDistance = ((ray.hit.transform.position.x * ray.hit.transform.position.x) + 
                            (ray.hit.transform.position.y * ray.hit.transform.position.y) +
                            (ray.hit.transform.position.z * ray.hit.transform.position.z));

        sqDist = Mathf.Sqrt(totalDistance);

        numOfTunnels = (int)Mathf.Ceil((sqDist / 2000f) * tunnelLimit);

        for (int i = 0; i < numOfTunnels; i++)
        {

            Debug.Log("warp triggered");
            GameObject newTunnel = (GameObject)Instantiate(warpTunnel, shipWarpOrigin.position, shipWarpOrigin.rotation);
            tunnelsSpawned.Add(newTunnel);

            lastAdded = tunnelsSpawned.Last().transform.Find("endpoint");

            shipWarpOrigin = lastAdded;

        }

    }

    void cancelWarp()
    {

        Debug.Log("warp canceled");
        GameObject[] warpTunnels = GameObject.FindGameObjectsWithTag("tunnelSpawn");

        foreach (GameObject warpTunnel in warpTunnels)
        {
            
            tunnelsSpawned.Remove(warpTunnel);

            Destroy(warpTunnel);

        } 
        
        return;

    }

    void speedReset()
    {

        Debug.Log("speeds reset i hope");

        if (shipCont.shipSpeed > 25.0f)
        {

            shipCont.shipSpeed = 25.0f;

        }


        shipCont.strafeSpeed = 2f;
        shipCont.turnSpeed = 0.325f;

        if (shield.activeInHierarchy == true)
        {

            shipCont.rotateRate = 175.0f;

        }

        if (shield.activeInHierarchy == false)
        {

            shipCont.rotateRate = 100.0f;

        }


    }

}
