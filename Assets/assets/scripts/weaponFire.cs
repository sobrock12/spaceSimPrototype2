using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weaponFire : MonoBehaviour
{
    public GameObject ship;

    public GameObject leftHand;
    public GameObject rightHand;

    public LineRenderer leftLineOffset;
    public LineRenderer rightLineOffset;

    //public float offset;

    public leftHandRaycast leftHandCast;
    public handRaycast rightHandCast;

    public GameObject leftReticle;
    public GameObject rightReticle;

    public float distance = 75.0f;

    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.085f;

    public GameObject leftWeapon;
    public GameObject rightWeapon;

    public Transform referencePoint;

    public Transform leftEmptyAim;
    public Transform rightEmptyAim;

    public bool leftCanShoot = false;
    public bool rightCanShoot = false;

    public GameObject projectile;

    public Transform leftProjectileOrigin;
    public Transform rightProjectileOrigin;

    public float rightTimer = 0.0f;
    public float leftTimer = 0.0f;

    public float correctedRightTimer;
    public float correctedLeftTimer;

    public float fireRate = 1.0f;

    public TextMeshPro left;
    public TextMeshPro right;

    void Start()
    {
        
        leftHandCast = leftHand.GetComponent<leftHandRaycast>();
        rightHandCast = rightHand.GetComponent<handRaycast>();

        leftLineOffset = leftHand.GetComponent<LineRenderer>();
        rightLineOffset = rightHand.GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        rightTimer += Time.deltaTime;
        leftTimer += Time.deltaTime;

        correctedRightTimer = Mathf.Clamp(rightTimer, 0.0f, 1.1f);
        correctedLeftTimer = Mathf.Clamp(leftTimer, 0.0f, 1.1f);

        RaycastHit leftHit = leftHandCast.leftUIHit;

        RaycastHit rightHit = rightHandCast.uiHit;

        RaycastHit leftShootHit = leftHandCast.leftShootHit;

        RaycastHit rightShootHit = rightHandCast.shootHit;

        if (rightHit.collider == null)
        {

            rightReticle.SetActive(false);
            rightWeapon.transform.LookAt(referencePoint);
            rightCanShoot = false;
        }

        if (leftHit.collider == null)
        {

            leftReticle.SetActive(false);
            leftWeapon.transform.LookAt(referencePoint);
            leftCanShoot = false;

        }

        if (leftShootHit.collider != null)
        {

            leftWeapon.transform.LookAt(leftShootHit.point);

        }

        if (leftShootHit.collider == null)
        {

            leftWeapon.transform.LookAt(leftEmptyAim);

        }

        if (rightShootHit.collider != null)
        {

            rightWeapon.transform.LookAt(rightShootHit.point);

        }

        if (rightShootHit.collider == null)
        {

            rightWeapon.transform.LookAt(rightEmptyAim);

        }

        if (rightHandCast.rightTriggerFull == false)
        {

            rightCanShoot = false;

        }

        if (rightHit.collider != null)
        {        
            
            rightReticle.SetActive(true);
            if (rightHit.collider.CompareTag("aimingBorder"))
            {

                Debug.Log($"found : {rightHit.collider.transform.name}");

            }

            if (rightHandCast.rightTriggerFull == true && rightTimer > fireRate)
            {

                Debug.Log("shoot right");
                rightCanShoot = true;

                if (rightCanShoot == true)
                {

                    Instantiate(projectile, rightProjectileOrigin.transform.position, rightWeapon.transform.rotation);
                    rightTimer = 0.0f;

                }

            }

        }

        if (rightHandCast.leftTriggerFull == false)
        {

            leftCanShoot = false;

        }

        if (leftHit.collider != null)
        {        
            
            leftReticle.SetActive(true);
            if (leftHit.collider.CompareTag("aimingBorder"))
            {

                Debug.Log($"found : {leftHit.collider.transform.name}");

            }

            if (rightHandCast.leftTriggerFull == true && leftTimer > fireRate)
            {

                Debug.Log("shoot left");
                leftCanShoot = true;

                if (leftCanShoot == true)
                {

                    Instantiate(projectile, leftProjectileOrigin.transform.position, leftWeapon.transform.rotation);
                    leftTimer= 0.0f;

                }

            }

        }

        if (rightTimer > 1.0f)
        {

            right.color = Color.green;

        }

        if (rightTimer < 1.0f)
        {

            right.color = Color.red;

        }

        if (leftTimer > 1.0f)
        {

            left.color = Color.green;

        }

        if (leftTimer < 1.0f)
        {

            left.color = Color.red;

        }

    }
}
