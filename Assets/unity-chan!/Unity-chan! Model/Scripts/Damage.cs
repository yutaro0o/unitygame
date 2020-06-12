using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float dmgDelay = 0.2f;//ダメージを受けた時にモーションに遷移するまでの待機時間
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Animatorのコンポーネントを取得
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        Invoke("DamageStart", dmgDelay);
    }
    void DamageStart()
    {
        anim.SetBool("Damage", true);
    }
    void DamageEnd()
    {
        anim.SetBool("Damage", false);
    }
}
