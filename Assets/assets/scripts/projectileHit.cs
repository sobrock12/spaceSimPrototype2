using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
//using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;

public class projectileHit : MonoBehaviour
{

    public GameObject objHit;
    public GameObject player;
    public statusVars stats;
    public enemyStats enemyStats;
    public shieldStatusVars shieldStats;
    public shipShield shield;
    public float damageVal;
    public float playerDamageVal;

    void Start()
    {

        player = GameObject.Find("ship1");

    }

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

        if (objHit.GetComponentInParent<enemyStats>() != null)
        {

            enemyStats = objHit.GetComponentInParent<enemyStats>();

            stats = player.GetComponent<statusVars>();

            playerDamageVal = stats.damage;

            enemyStats.gotHit(playerDamageVal);

        }

    }

}
