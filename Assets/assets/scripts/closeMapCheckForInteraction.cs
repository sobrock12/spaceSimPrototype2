using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeMapCheckForInteraction : MonoBehaviour
{

    public GameObject mapObject;
    public GameObject mapCanvas;
    public GameObject uiCanvas;
    public mapCheckForInteraction interaction;
    public Collider myCollider;
    public GameObject ship;
    public shipController shipController;


    // Start is called before the first frame update
    void Start()
    {

        interaction = mapObject.GetComponent<mapCheckForInteraction>();
        myCollider = GetComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (interaction.currentlySelectedRight == myCollider && interaction.triggerIsPressed == true)
        {

            //Debug.Log("it worked brotherman");
            mapCanvas.SetActive(false);
            uiCanvas.SetActive(true);

            shipController = ship.GetComponent<shipController>();

            shipController.enabled = true;


        }

    }

}
