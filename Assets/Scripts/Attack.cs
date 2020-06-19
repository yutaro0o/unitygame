using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    public CapsuleCollider capsuleCollider;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //マウスの右クリックでアタックに遷移させる
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("Attack", true);
        }
    }

    void Attack1Start()
    {
        //武器のカプセルコライダーをオンにする
        capsuleCollider.enabled = true;
    }
    void Attack1End()
    {
        //武器のカプセルコライダーをオフにする
        capsuleCollider.enabled = false;
        //アタックの遷移を終わらせる
        anim.SetBool("Attack", false);
    }
}
