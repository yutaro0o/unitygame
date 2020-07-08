using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseObstacleController : MonoBehaviour
{
    [SerializeField]
    protected float waitTime = 0;//目的地に着いたとき、原点に返ってきたときに停止する時間
    protected bool stop = false;
    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {

    }
    protected virtual void FixedUpdate()
    {

    }
    protected virtual IEnumerator WaitTimer()
    {
        stop = true;
        yield return new WaitForSeconds(waitTime);//処理をwaitTime停止
        stop = false;
    }
}