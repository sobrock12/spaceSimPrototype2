using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftHandRaycast : MonoBehaviour
{

    public GameObject leftHand;
    public LineRenderer leftLineOffset;

    public float uiDistance = 100.0f;
    public float shootDistance = 100.0f;
    public float targetDist = 200.0f;

    [SerializeField] private LayerMask aimingBorder;
    [SerializeField] private LayerMask whatCanIShoot;
    [SerializeField] private LayerMask enemy;

    public RaycastHit leftUIHit;

    public RaycastHit leftShootHit;

    public RaycastHit enemyUIBar;

    // Start is called before the first frame update
    void Start()
    {

        leftLineOffset = leftHand.GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 leftOffset = leftLineOffset.GetPosition(1);

        Physics.Raycast(transform.position, transform.TransformDirection(leftOffset), out leftUIHit, uiDistance, aimingBorder);

        Physics.Raycast(transform.position, transform.TransformDirection(leftOffset), out leftShootHit, shootDistance, whatCanIShoot);

        Physics.Raycast(transform.position, transform.TransformDirection(leftOffset), out enemyUIBar, targetDist, enemy);

    }
}
