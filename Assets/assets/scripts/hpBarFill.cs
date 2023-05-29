using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBarFill : MonoBehaviour
{

    public GameObject ship;
    public Image fill;
    public float amount;
    public float amountMax;
    public statusVars hpStats;
    public float adjustedAmount;

    // Start is called before the first frame update
    void Start()
    {

        hpStats = ship.GetComponent<statusVars>();
        amountMax = hpStats.hpMax;
        fill = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {

        amount = hpStats.currentHealth;

        adjustedAmount = amount/amountMax;

        fill.fillAmount = adjustedAmount;
        
    }
}
