using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveFloor : BaseObstacleController
{
    [SerializeField]
    protected float moveX = 0;//X方向の移動量
    [SerializeField]
    protected float moveY = 0;//Y方向の移動量
    [SerializeField]
    protected float moveZ = 0;//Z方向の移動量
    [SerializeField]
    protected float speed = 0;//移動速度
    protected float step;//1フレームで進む量
    protected bool goBack = false;//戻るフラグ(falseの間は目的地へ進み,trueの間は原点へ帰る)
    protected Vector3 origin;//原点
    protected Vector3 destination;//目的地
    protected override void Start()
    {
        origin = transform.position;//原点の位置を記録
        destination = new Vector3(origin.x - moveX, origin.y - moveY, origin.z - moveZ);//目的地への移動量を記録
    }
    protected override void FixedUpdate()
    {
        if (stop)
        {
            return;
        }
        step = speed * Time.deltaTime;
        if (!goBack)//目的地へ進む
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
            if (transform.position == destination)//目的地に着いたら
            {
                goBack = true;//戻るフラグオン
                StartCoroutine(WaitTimer());//コルーチンでwaitTime止める
            }
        }
        else//原点へ帰る
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, step);
            if (transform.position == origin)//原点に着いたら
            {
                goBack = false;//戻るフラグオフ
                StartCoroutine(WaitTimer());//コルーチンでwaitTime止める
            }
        }
    }
    protected virtual void OnCollisionEnter(Collision other)//乗ったら
    {
        if (other.gameObject.CompareTag("Player"))//プレイヤータグのついたオブジェクトなら
        {
            other.gameObject.transform.SetParent(gameObject.transform);//プレイヤーを子オブジェクトにする
        }
    }
    protected virtual void OnCollisionExit(Collision other)//離れたら
    {
        if (other.gameObject.CompareTag("Player"))//プレイヤータグをつけたオブジェクトなら
        {
            other.gameObject.transform.SetParent(null);//子オブジェクトから外す
        }
    }
}