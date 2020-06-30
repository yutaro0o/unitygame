using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    public Animator anim;
    //Cボタンで立ちしゃがみを切り替える
    public static bool Crouchflg = false;

    static int stateCrouch = Animator.StringToHash("Base Layer.Crouch");
    static int stateCrouchWalk = Animator.StringToHash("Base Layer.Crouch Walk");
    static int stateRun = Animator.StringToHash("Base Layer.Run");
    static int stateSlide = Animator.StringToHash("Base Layer.Slide");
    private AnimatorStateInfo currentBaseState;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

        if(currentBaseState.fullPathHash == stateRun)
        {
            anim.SetBool("Crouch", false);
            Crouchflg = false;
        }

        if (currentBaseState.fullPathHash != stateCrouch && currentBaseState.fullPathHash != stateCrouchWalk && currentBaseState.fullPathHash != stateSlide)
        {
            GetComponent<CapsuleCollider>().enabled = true;
        }
        else
        {
            GetComponent<CapsuleCollider>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if(!Crouchflg)
            {
                anim.SetBool("Crouch", true);
                Crouchflg = true;
            }
            else
            {
                anim.SetBool("Crouch", false);
                Crouchflg = false;
            }
        }
    }
    public bool CrouchJudge()
    {
        return Crouchflg;
    }
}
