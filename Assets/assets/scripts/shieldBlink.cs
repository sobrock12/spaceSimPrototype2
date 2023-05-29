using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldBlink : MonoBehaviour
{
    public float alphaVar;
    public float max = 25.0f;

    public float rate = 0.5f;
    public bool gotHit = false;
    public bool full = false;

    public shipShield shield;

    public GameObject shieldInside;

    public Material shieldMat;

    void Start()
    {

        shield = GetComponent<shipShield>();
        shieldMat = GetComponent<SkinnedMeshRenderer>().material;

    }


    void Update()
    {

        //short blink
        if (gotHit == true)
        {
            shieldInside.SetActive(true);
            alphaVar += rate * Time.deltaTime;
            alphaVar = Mathf.Clamp(alphaVar, 0.0f, max);

        }

        if (alphaVar >= max)
        {

            full = true;

        }

        if (full == true)
        {
            gotHit = false;
            alphaVar -= rate * Time.deltaTime;
            alphaVar = Mathf.Clamp(alphaVar, 0.0f, max);

        }

        if (alphaVar <= 0.0f)
        {

            gotHit = false;
            full = false;
            shieldInside.SetActive(false);

        }

        setAlpha(alphaVar / 100);

    }

    void setAlpha(float alpha)
    {

        Color color = shieldMat.color;
        color.a = alpha;
        shieldMat.color = color;

    }

}
