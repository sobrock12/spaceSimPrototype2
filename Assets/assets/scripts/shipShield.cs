using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipShield : MonoBehaviour
{

    public GameObject ship;
    public shipController sc;
    public Rigidbody shipRb;
    public float shieldHP;
    public float recharge = 0.0f;
    public float rechargeRate = 0.5f;
    public float chargeTimer = 0.0f;
    public float timerLimit = 3.0f;

    public GameObject shield;

    public GameObject player;

    public shieldStatusVars stats;

    // Start is called before the first frame update
    void Start()
    {

        shipRb = ship.GetComponent<Rigidbody>();
        sc = ship.GetComponent<shipController>();
        stats = player.GetComponent<shieldStatusVars>();

    }

    // Update is called once per frame
    void Update()
    {
        shieldHP = stats.currentShield;

        shieldHP = Mathf.Clamp(shieldHP, 0.0f, 100.0f);
        recharge = Mathf.Clamp(recharge, 0.0f, 1.0f);

        if (shieldHP <= 0.0f)
        {

            shield.SetActive(false);
            shipRb.mass = 1.0f;
            sc.rotateRate = 125.0f;


        }

        if (recharge == 1.0f)
        {

            shieldHP = stats.shieldMax;
            shield.SetActive(true);
            shipRb.mass = 0.50f;
            sc.rotateRate = 250.0f;

        }

        if (recharge <= 1.0f)
        {

            chargeTimer = Mathf.Clamp(chargeTimer, 0.0f, 3.0f);
            chargeTimer += Time.deltaTime;

            if (chargeTimer >= timerLimit)
            {

                recharge += rechargeRate * Time.deltaTime;

            }

        }

        stats.currentShield = shieldHP;

    }

    public void resetVals()
    {

        recharge = 0.0f;
        chargeTimer = 0.0f;

    }

}
