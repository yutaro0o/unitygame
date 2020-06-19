using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animator anim = GetComponent<Animator>();
        //マウスの左ボタンが押されている間盾を構える
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("Hold", true);
        }
        else
        {
            anim.SetBool("Hold", false);
        }
    }
}
