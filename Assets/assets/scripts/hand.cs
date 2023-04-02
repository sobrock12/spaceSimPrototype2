using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{

    Animator animator;
    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    public float speed;
    private string animatorGripParam = "Grip";
    private string triggerGripParam = "Trigger";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        animateHand();
        
    }
    
    internal void SetGrip(float v)
    {

        gripTarget = v;

    }

    internal void SetTrigger(float v)
    {

        triggerTarget = v;

    }

    void animateHand()
    {

        if (gripCurrent != gripTarget)
        {

            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);

        }
        
        if (triggerCurrent != triggerTarget)
        {

            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(triggerGripParam, triggerCurrent);

        }

    }

}
