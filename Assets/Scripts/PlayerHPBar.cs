using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //最大HPと現在のHP
    public int maxHP = 100;
    public int currentHP;
    //Sliderを入れる
    public Slider slider;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHP = maxHP;
    }
    void Update()
    {
        //最大HPにおける現在のHPをSliderに反映、小数点以下反映のためにfloat型に変換
        slider.value = (float)currentHP / (float)maxHP;
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnCollisionStay(Collision collision)
    {
        //DangerBlockタグのオブジェクトに触れると発動
        if (collision.gameObject.tag == "DangerBlock" || collision.gameObject.tag == "Enemy")
        {
            //ダメージは1～100の中でランダムに決める。
            int damage = 1;//Random.Range(1, 100);

            //現在のHPからダメージを引く
            currentHP -= damage;
        }
    }

    public int ReturnCurrentHP()
    {
        return currentHP;
    }
}