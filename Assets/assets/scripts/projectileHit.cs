using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
//using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;

public class projectileHit : MonoBehaviour
{

    public GameObject objHit;
    public statusVars stats;
    public enemyStats enemyStats;
    public shieldStatusVars shieldStats;
    public shipShield shield;
    public float damageVal;
    public float playerDamageVal;

    private void OnCollisionEnter(Collision collision)
    {
        
        objHit = collision.gameObject;

        if (objHit.GetComponent<statusVars>() != null && objHit.GetComponent<shieldStatusVars>() != null)
        {
            shield = objHit.GetComponentInChildren<shipShield>();

            stats = objHit.GetComponent<statusVars>();

            if (shield != null)
            {

                shield.resetVals();

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

        if (objHit.GetComponent<enemyStats>() != null)
        {

            enemyStats = objHit.GetComponent<enemyStats>();

            playerDamageVal = stats.damage;

            enemyStats.gotHit(playerDamageVal);

        }

    }

}
