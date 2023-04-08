using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileFire : MonoBehaviour
{

    public float speed = 20.0f;
    public Rigidbody rb;    
    public GameObject spark;
    public ContactPoint point;
    public Quaternion sparkRot;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        point = collision.GetContact(0);
        sparkRot = Quaternion.Euler(point.point.x, point.point.y, point.point.z);
        Instantiate(spark, point.point, sparkRot);
        gameObject.SetActive(false);

    }

    private void OnDisable()
    {

        Destroy(gameObject);

    }
}
