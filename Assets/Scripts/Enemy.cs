using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public static float hp = 10.0f;
    [SerializeField] public static float atk = 5.0f;
    [SerializeField] public static float def = 1.0f;

    [SerializeField] float dmgDelay = 0.2f;//ダメージを受けた時にモーションに遷移するまでの待機時間
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Animatorのコンポーネントを取得
        anim = GetComponent<Animator>();
    }

    //物体がすり抜けた時に呼び出し
    void OnTriggerEnter(Collider other)
    {
        //DamageStartを開始するまでdmgDelay分遅延させる
        Invoke("DamageStart", dmgDelay);
        //hpbar.DamageCalc(player.ReturnAtk(), def);
    }
    //DamageAnimationの開始
    void DamageStart()
    {
        anim.SetBool("Damage", true);
        Destroy(this.gameObject, 1.9f);
    }
    //DamageAnimationの終了
    void DamageEnd()
    {
        anim.SetBool("Damage", false);
    }
}
