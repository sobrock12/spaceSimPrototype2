using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusVars : MonoBehaviour
{

    public float max = 100.0f;
    public float currentHealth;
    public float currentShield;

    // Update is called once per frame
    void Update()
    {

        
        
    }

    public void subHealth(float damageAmount)
    {

        currentHealth -= damageAmount;
        //currentHealth = Mathf.Clamp(currentHealth, 0, max);

    }

    public void addHealth(float amount)
    {

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, max);

    }

}
