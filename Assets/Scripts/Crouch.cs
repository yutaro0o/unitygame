using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    Animator anim;
    //Cボタンで立ちしゃがみを切り替える
    public static bool Crouchflg = false;

    static int stateRun = Animator.StringToHash("Base Layer.Run");
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
