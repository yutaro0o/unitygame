using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerBlock : MonoBehaviour
{
    [SerializeField] float contactdamage = 1.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //.DamagePenetration(contactdamage);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //相手のタグがSwordならば、自分を消す
        if (other.gameObject.tag == "Sword")
        {
            Destroy(this.gameObject, 0.2f);//0.2秒遅延させて消す
        }
    }
}
