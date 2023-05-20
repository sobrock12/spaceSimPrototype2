using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusVars : MonoBehaviour
{

    public float hpMax = 100.0f;
    public float startingHealth;
    public float currentHealth;
    /*
    public float shieldMax = 100.0f;
    public float startingShield;
    public float currentShield;
    */

    // Update is called once per frame
    void Start()
    {

        startingHealth = hpMax;
        currentHealth = startingHealth;

        //currentShield = 0.0f;

    }

    public void subHealth(float damageAmount)
    {

        currentHealth -= damageAmount;
        //currentHealth = Mathf.Clamp(currentHealth, 0, max);

    }

    public void addHealth(float amount)
    {

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, hpMax);

    }
    /*
    public void subShield(float damageAmount)
    {
    
        currentShield -= damageAmount;
    
    }
    */

}
