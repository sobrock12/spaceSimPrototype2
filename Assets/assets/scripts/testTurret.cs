using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class testTurret : MonoBehaviour
{

    public GameObject projectile;

    public GameObject projOrigin;

    public bool canFire;

    // Start is called before the first frame update
    void Awake()
    {

        StartCoroutine(waitToFire());

    }

    IEnumerator waitToFire()
    {

        yield return new WaitForSeconds(2);

        canFire = true;
        Instantiate(projectile, projOrigin.transform.position, projOrigin.transform.rotation);

        yield return new WaitForSeconds(1);

        canFire = false;
        StartCoroutine(waitToFire());

    }

}
