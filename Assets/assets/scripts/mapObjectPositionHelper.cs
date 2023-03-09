using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapObjectPositionHelper : MonoBehaviour
{

    public GameObject sun;
    public GameObject planet;
    public Vector3 newPos;
    public float scalar = 100000f;

    /*void Update()
    {

        findPos();

    }*/

    public void findPos()
    {

        newPos = planet.transform.position - sun.transform.position;

        newPos = newPos / scalar;

        transform.localPosition = newPos;

    }

}
