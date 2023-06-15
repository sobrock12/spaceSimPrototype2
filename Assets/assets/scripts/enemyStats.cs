using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : MonoBehaviour
{

    public float hp;
    public float maxHp = 100.0f;


    // Start is called before the first frame update
    void Start()
    {

        hp = maxHp;
        
    }

    public void gotHit(float val)
    {

        hp -= val;

    }

    void Update()
    {

        if (hp <= 0)
        {

            Destroy(gameObject);

        }

    }

}
