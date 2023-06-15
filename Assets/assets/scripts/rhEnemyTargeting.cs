using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhEnemyTargeting : MonoBehaviour
{

    public GameObject rightHand;
    public handRaycast rhRay;
    public RaycastHit enemyHit;

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
        
    }
}
