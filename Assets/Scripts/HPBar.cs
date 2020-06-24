using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    Slider slider;
    float hp;

    // Start is called before the first frame update
    void Start()
    {
        //Player player = new Player();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        //hpをSliderコンポーネントのmaxvalueを取得し体力満タンの状態でゲームを開始
        //slider.maxValue = player.ReturnHp();
        //hp = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = hp;
    }

    public void DamageCalc(float atk, float def)
    {
        if (atk > def)
        {
            hp -= atk - def;
        }
    }

    public void DamagePenetration(float atk)
    {
        hp -= atk;
    }
}