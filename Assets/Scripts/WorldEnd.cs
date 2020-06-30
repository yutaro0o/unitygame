using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEnd : MonoBehaviour
{
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
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //相手のタグがSwordならば、自分を消す
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject enemy in enemys)
            {
                enemy.SetActive(false);
            }
            Destroy(this.gameObject);
        }
    }
}
