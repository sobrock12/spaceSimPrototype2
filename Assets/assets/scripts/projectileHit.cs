using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileHit : MonoBehaviour
{
    public GameObject objHit;
    public statusVars stats;
    public float damageVal;


    private void OnCollisionEnter(Collision collision)
    {
        
        objHit = collision.gameObject;

        if (objHit.GetComponent<statusVars>() != null)
        {

            stats = objHit.GetComponent<statusVars>();

            stats.subHealth(damageVal);

        }

    }
}
