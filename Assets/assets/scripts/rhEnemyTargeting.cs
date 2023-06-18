using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rhEnemyTargeting : MonoBehaviour
{

    public GameObject rightHand;
    public handRaycast rhRay;
    public RaycastHit enemyHit;
    public GameObject uiBar;
    public Image barFill;
    public float fillAmount;
    public GameObject enemy;
    public enemyStats enemyStats;

    public bool targetAquired = false;


    // Start is called before the first frame update
    void Start()
    {

        rhRay = rightHand.GetComponent<handRaycast>();
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHit = rhRay.enemyUIBar;

        if (enemyHit.collider != null)
        {

            targetAquired = true;

        }

        if (enemyHit.collider == null)
        {

            targetAquired = false;

        }
        
        if (targetAquired == true)
        {

            uiBar.SetActive(true);
            enemy = enemyHit.collider.gameObject;
            enemyStats = enemy.GetComponentInParent<enemyStats>();
            fillAmount = enemyStats.hp / enemyStats.maxHp;
            barFill.fillAmount = fillAmount;

        }

        if (targetAquired == false)
        {

            uiBar.SetActive(false);

        }


    }
}
