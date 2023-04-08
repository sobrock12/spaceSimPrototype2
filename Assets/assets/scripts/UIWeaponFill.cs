using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponFill : MonoBehaviour
{

    public GameObject ship;
    public weaponFire fireScript;
    public float leftFill;
    public float rightFill;
    public Image leftWeaponCharge;
    public Image rightWeaponCharge;

    void Start()
    {

        fireScript = ship.GetComponent<weaponFire>();
        
    }

    // Update is called once per frame
    void Update()
    {

        leftFill = fireScript.correctedLeftTimer;
        rightFill = fireScript.correctedRightTimer;

        leftWeaponCharge.fillAmount = leftFill;
        rightWeaponCharge.fillAmount = rightFill;
        
    }
}
