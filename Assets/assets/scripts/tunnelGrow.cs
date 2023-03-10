using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunnelGrow : MonoBehaviour
{

    public Vector3 scale = Vector3.one;
    public float xScale;
    public float xMin = 0.0f;
    public float xMax = 17000.0f;
    public float yScale;
    public float yMin = 0.0f;
    public float yMax = 17000.0f;
    public float zScale;
    public float zMin = 0.0f;
    public float zMax = 50000.0f;
    public float growSpeed;

    // Start is called before the first frame update
    void Start()
    {

        transform.localScale = scale;
        
    }

    // Update is called once per frame
    void Update()
    {
        xScale += growSpeed;
        xScale = Mathf.Clamp(xScale, xMin, xMax);

        yScale += growSpeed;
        yScale = Mathf.Clamp(yScale, yMin, yMax);

        zScale += growSpeed;
        zScale = Mathf.Clamp(zScale, xMin, zMax);

        scale = new Vector3(xScale, yScale, zScale);

        transform.localScale = scale;

    }
}
