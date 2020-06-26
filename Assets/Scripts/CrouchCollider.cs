﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCollider : MonoBehaviour
{
    public Animator anim;
    static int stateCrouch = Animator.StringToHash("Base Layer.Crouch");
    static int stateCrouchWalk = Animator.StringToHash("Base Layer.Crouch Walk");
    static int stateSlider = Animator.StringToHash("Base Layer.Slider");
    private AnimatorStateInfo currentBaseState;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        if (currentBaseState.fullPathHash != stateCrouch && currentBaseState.fullPathHash != stateCrouchWalk && currentBaseState.fullPathHash != stateSlider)
        {
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            GetComponent<CapsuleCollider>().enabled = true;
        }
        
    }
}