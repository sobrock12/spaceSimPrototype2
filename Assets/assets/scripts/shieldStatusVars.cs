using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldStatusVars : MonoBehaviour
{

    public float shieldMax = 100.0f;
    public float startingShield;
    public float currentShield;
    public shieldBlink blink;

    // Start is called before the first frame update
    void Start()
    {

        currentShield = 0.0f;
        blink = GetComponentInChildren<shieldBlink>();

    }

    public void subShield(float damageAmount)
    {

        currentShield -= damageAmount;
        blink.gotHit = true;

    }


}
