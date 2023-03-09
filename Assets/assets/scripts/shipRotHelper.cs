using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipRotHelper : MonoBehaviour
{

    public GameObject ship;
    public Quaternion newRot;

    public void findRot()
    {

        newRot = ship.transform.rotation;

        transform.localRotation = newRot;

    }

}
