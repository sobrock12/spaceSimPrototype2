using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableWeaponsOnMap : MonoBehaviour
{

    public GameObject map;
    public weaponFire shoot;

    void Start()
    {

        shoot = GetComponent<weaponFire>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (map.activeSelf == true)
        {

            shoot.enabled = false;

        }

        if (map.activeSelf == false)
        {

            shoot.enabled = true;

        }

    }
}
