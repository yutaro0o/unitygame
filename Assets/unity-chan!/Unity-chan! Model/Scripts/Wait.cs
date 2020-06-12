using UnityEngine;

public class Wait : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animator anim = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.Alpha1))
        {
            anim.SetBool("Wait01", true);
        }
        else
        {
            anim.SetBool("Wait01", false);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            anim.SetBool("Wait02", true);
        }
        else
        {
            anim.SetBool("Wait02", false);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            anim.SetBool("Wait03", true);
        }
        else
        {
            anim.SetBool("Wait03", false);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            anim.SetBool("Wait04", true);
        }
        else
        {
            anim.SetBool("Wait04", false);
        }
    }
}
