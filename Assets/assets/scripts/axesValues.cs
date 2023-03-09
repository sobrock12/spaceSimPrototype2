using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class axesValues : MonoBehaviour
{

    private TMPro.TMP_Text rotationText;
    public GameObject steering;
    private float upDown;
    private float leftRight;


    // Start is called before the first frame update
    void Start()
    {

        rotationText = GetComponent<TMP_Text>();


    }

    // Update is called once per frame
    void Update()
    {

        upDown = steering.transform.localRotation.x;
        leftRight = steering.transform.localRotation.z;

        rotationText.text = "up/down = " + upDown  + "   left/right = " + leftRight;

    }
}
