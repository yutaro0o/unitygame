using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float hp = 10.0f;
    [SerializeField] public float atk = 5.0f;
    [SerializeField] public float def = 1.0f;

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
        //hpbar.DamageCalc(enemy.ReturnAtk(), def);
    }

    public void Win()
    {
        anim.SetBool("Win", true);
    }
    public void Lose()
    {
        anim.SetBool("Lose", true);
    }
    //DamageAnimationの開始
    void DamageStart()
    {
        anim.SetBool("Damage", true);
    }
    //DamageAnimationの終了
    void DamageEnd()
    {
        anim.SetBool("Damage", false);
    }
}
