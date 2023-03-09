using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapSpawner : MonoBehaviour
{

    public GameObject mapCanvas;
    public GameObject uiCanvas;
    public mapObjectPositionHelper mapHelper;
    public shipRotHelper rotHelper;
    [SerializeField] public List<GameObject> mapObjects = new List<GameObject>();
    public GameObject ship;
    public shipController shipController;

    public void spawnMap()
    {

        //Debug.Log("it worked again you son of a bitch!");

        mapCanvas.SetActive(true);
        uiCanvas.SetActive(false);

        shipController = ship.GetComponent<shipController>();

        shipController.enabled = false;

        //when spawnMap is ran, run through list
        //find mapObjectPositionHelper component
        //run findPos() for each item in list;
        foreach (GameObject obj in mapObjects)
        {

            mapHelper = obj.GetComponent<mapObjectPositionHelper>();

            mapHelper.findPos();

            if (obj.GetComponent<shipRotHelper>() != null)
            {

                rotHelper = obj.GetComponent<shipRotHelper>();

                rotHelper.findRot();

            }

        }

    }

}
