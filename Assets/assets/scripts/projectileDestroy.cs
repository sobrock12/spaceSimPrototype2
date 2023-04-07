using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileDestroy : MonoBehaviour
{

    void Awake()
    {

        StartCoroutine(Wait());
        
    }

    // Update is called once per frame

    IEnumerator Wait()
    {

        yield return new WaitForSeconds(3);

        Destroy(gameObject);

    }

}
