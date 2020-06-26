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
        //相手のタグがSwordならば、自分を消す
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
