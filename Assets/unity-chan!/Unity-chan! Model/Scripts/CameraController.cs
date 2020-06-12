// PlayerFollowCamera.cs
using System.Runtime.InteropServices;
using UnityEngine;

// プレイヤー追従カメラ
public class CameraController : MonoBehaviour
{
    //[SerializeField] private float turnSpeed = 5.0f;   // 回転速度
    [SerializeField] private Transform player;         // 注視対象プレイヤー

    [SerializeField] private float distance = 4.0f;    // 注視対象プレイヤーからカメラを離す距離
    [SerializeField] public Quaternion hRotation;      // カメラの水平回転
    [SerializeField] private Quaternion vRotation;     // カメラの垂直回転(見下ろし回転)


    void Start()
    {
        // 回転の初期化
        vRotation = Quaternion.AngleAxis(0, Vector3.up);         // 垂直回転(X軸を軸とする回転)は0度
        hRotation = Quaternion.AngleAxis(0, Vector3.right);            // 水平回転(Y軸を軸とする回転)も0度
        transform.rotation = hRotation * vRotation;                 // 最終的なカメラの回転は、垂直回転してから水平回転する合成回転

        // 位置の初期化
        // player位置から距離distanceだけ手前に引いた位置を設定します
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
    }

    void LateUpdate()
    {
        float InputX = Input.GetAxis("Mouse X");
        float InputY = Input.GetAxis("Mouse Y");
        if (InputY > 90)
        {
            InputY = 90;
        }
        else if (InputY < -70)
        {
            InputY = -70;
        }
        else
        {
            InputY = Input.GetAxis("Mouse Y");
        }
        // 水平回転の更新
        hRotation *= Quaternion.AngleAxis(InputX, Vector3.up);
        //垂直回転の更新
        vRotation *= Quaternion.AngleAxis(InputY, Vector3.right);

        // カメラの回転(transform.rotation)の更新
        // 方法1 : 垂直回転してから水平回転する合成回転とします
        transform.rotation = hRotation * vRotation;

        // カメラの位置(transform.position)の更新
        // player位置から距離distanceだけ手前に引いた位置を設定します(位置補正版)
        transform.position = player.position + new Vector3(0, 2.5f, 0) - transform.rotation * Vector3.forward * distance;
    }
}