using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;

public class projectileHit : MonoBehaviour
{

    public GameObject objHit;
    public statusVars stats;
    public shieldStatusVars shieldStats;
    public shipShield shield;
    public float damageVal;

    private void OnCollisionEnter(Collision collision)
    {
        
        objHit = collision.gameObject;

        if (objHit.GetComponent<statusVars>() != null && objHit.GetComponent<shieldStatusVars>() != null)
        {
            shield = objHit.GetComponentInChildren<shipShield>();

            stats = objHit.GetComponent<statusVars>();

            if (shield != null)
            {

                shield.recharge = 0.0f;
                shield.chargeTimer = 0.0f;

            }

            shieldStats = objHit.GetComponent<shieldStatusVars>();

            if (shieldStats.currentShield > 0.0f)
            {

                shieldStats.subShield(damageVal);

            }

            if (shield.stats.currentShield <= 0.0f)
            {

                stats.subHealth(damageVal);

            }

        }

    }

}
