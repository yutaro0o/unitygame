using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Animator anim = GetComponent<Animator>();

        if(Input.GetKey(KeyCode.F))
        {
            anim.SetBool("PickUp", true);
        }
        else
        {
            anim.SetBool("PickUp", false);
        }
    }
}
