using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuelBarFill : MonoBehaviour
{
    public GameObject ship;
    public Image fill;
    public float amount;
    public float amountMax;
    public statusVars fuelStats;
    public float adjustedAmount;

    // Start is called before the first frame update
    void Start()
    {

        fuelStats = ship.GetComponent<statusVars>();
        amountMax = fuelStats.fuelMax;
        fill = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {

        amount = fuelStats.currentFuel;

        adjustedAmount = amount / amountMax;

        fill.fillAmount = adjustedAmount;
        
    }
}
