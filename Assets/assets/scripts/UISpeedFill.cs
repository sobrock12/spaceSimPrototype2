using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UISpeedFill : MonoBehaviour
{

    public GameObject ship;
    public shipController shipInfo;
    public float speed;
    public Image speedImage;

    // Start is called before the first frame update
    void Start()
    {

        shipInfo = ship.GetComponent<shipController>();

    }

    // Update is called once per frame
    void Update()
    {

        speed = shipInfo.shipSpeed;

        speedImage.fillAmount = Mathf.Clamp(speed / shipInfo.maxSpeed, 0f, 1f);

    }
}
