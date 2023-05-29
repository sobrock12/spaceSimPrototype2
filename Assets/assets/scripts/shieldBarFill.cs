using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldBarFill : MonoBehaviour
{

    public GameObject ship;
    public Image fill;
    public float amount;
    public float amountMax;
    public shieldStatusVars shieldStats;
    public float adjustedAmount;

    // Start is called before the first frame update
    void Start()
    {

        shieldStats = ship.GetComponent<shieldStatusVars>();
        amountMax = shieldStats.shieldMax;
        fill = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {

        amount = shieldStats.currentShield;

        adjustedAmount = amount / amountMax;

        fill.fillAmount = adjustedAmount;
        
    }
}
