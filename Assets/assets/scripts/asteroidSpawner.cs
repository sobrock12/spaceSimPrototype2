using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroids;
    public Transform asteroidSpawnerParent;
    public int smallLimit;
    public float xLoClamp;
    public float xHiClamp;
    public float yLoClamp;
    public float yHiClamp;
    public float zLoClamp;
    public float zHiClamp;
    public float scaleLoClamp;
    public float scaleHiClamp;
    public float xRotLoClamp;
    public float xRotHiClamp;
    public float yRotLoClamp;
    public float yRotHiClamp;
    public float zRotLoClamp;
    public float zRotHiClamp;
    public bool isColliding = false;

    void Start()
    {

        for (int i = 0; i < smallLimit; i++)
        {

            transformChecker();

        }
        
    }

    void transformChecker()
    {
        isColliding = false;

        int randomNum = Random.Range(0, 8);


        float scaleMult = Random.Range(scaleLoClamp, scaleHiClamp);
        float xRot = Random.Range(xRotLoClamp, xRotHiClamp);
        float yRot = Random.Range(yRotLoClamp, yRotHiClamp);
        float zRot = Random.Range(zRotLoClamp, zRotHiClamp);

        float xPos = Random.Range(xLoClamp, xHiClamp);
        float yPos = Random.Range(yLoClamp, yHiClamp);
        float zPos = Random.Range(zLoClamp, zHiClamp);
        Vector3 pos = new Vector3(xPos, yPos, zPos);

        GameObject asteroid = Instantiate(asteroids[randomNum], asteroidSpawnerParent, false);

        asteroid.transform.localPosition = (pos);
        //asteroid.transform.forward = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        //asteroid.transform.forward = pos;
        asteroid.transform.localScale = transform.localScale * scaleMult;
        asteroid.transform.rotation = Quaternion.Euler(xRot, yRot, zRot);



    }

}
