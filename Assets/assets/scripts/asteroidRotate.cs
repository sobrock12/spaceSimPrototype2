using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class asteroidRotate : MonoBehaviour
{

    public GameObject origin;
    //public Vector3 direction;
    public float angle;
    public float speed;
    public float radius = 10f;

    void Awake()
    {

        /*
        origin = transform.parent.gameObject;

        direction = (transform.position - origin.transform.position).normalized;

        radius = Vector3.Distance(origin.transform.position, transform.position);
        */

        StartCoroutine(delay(2f));

    }

    
    void Update()
    {
        angle += speed * Time.deltaTime;

        if (angle > 360)
        {

            angle -= 360;

        }

        Vector3 orbit = Vector3.forward * radius;

        //orbit = Quaternion.LookRotation(direction) * Quaternion.Euler(0, angle, 0) * orbit;

        orbit = Quaternion.Euler(0, angle, 0) * orbit;


        transform.position = origin.transform.position + orbit;

    }
    
    IEnumerator delay (float time)
    {

        yield return new WaitForSeconds(time);

        origin = transform.parent.gameObject;

        //direction = (transform.position - origin.transform.position).normalized;

        radius = Vector3.Distance(origin.transform.position, transform.position);

        Invoke("Update", 2f);

    }
}
