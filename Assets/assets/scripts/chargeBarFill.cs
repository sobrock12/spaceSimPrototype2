using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chargeBarFill : MonoBehaviour
{

    public GameObject shield;
    public Image fill;
    public float amount;
    public shipShield chargeStats;

    // Start is called before the first frame update
    void Start()
    {

        chargeStats = shield.GetComponent<shipShield>();
        fill = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {

        amount = chargeStats.recharge;
        fill.fillAmount = amount;
        
    }
}
