using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject Player;
    Animator anim;
    private Rigidbody PlayerRigid;
    public float Upspeed;
    bool IsJump = false;

    PlayerController speed = new PlayerController();

    static int stateRun = Animator.StringToHash("Base Layer.Run");
    static int stateIdle = Animator.StringToHash("Base Layer.Idle");
    static int stateWalk = Animator.StringToHash("Base Layer.Walk");

    private AnimatorStateInfo currentBaseState;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerRigid = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

        if (currentBaseState.fullPathHash == stateIdle || currentBaseState.fullPathHash == stateWalk || currentBaseState.fullPathHash == stateRun)
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsJump == false)
            {
                if (speed.moveSpeed > 5.0)
                {
                    IsJump = true;
                    anim.SetBool("Jump", true);
                    Invoke("RunningJump", 0.3f);
                }
                else
                {
                    IsJump = true;
                    anim.SetBool("Jump", true);
                    SmallJump();
                }
            }
        }
        else
        {
            anim.SetBool("Jump", false);
            IsJump = false;
        }
    }

    void RunningJump()
    {
        PlayerRigid.AddForce(transform.up * Upspeed * 2);
    }
    void SmallJump()
    {
        PlayerRigid.AddForce(transform.up * Upspeed);
    }
}
