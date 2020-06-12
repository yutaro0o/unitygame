﻿// Player.cs
using UnityEngine;

// プレイヤー
public class PlayerController : MonoBehaviour
{

    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] private float moveSpeed = 0.0f;        // 移動速度(キー入力をしないときは移動速度0)
    [SerializeField] private float walkSpeed = 3.0f;        // 歩き速度
    [SerializeField] private float runSpeed = 7.0f;         // 走り速度
    [SerializeField] private float applySpeed = 0.2f;       // 振り向きの適用速度
    [SerializeField] private CameraController refCamera;    // カメラの水平回転を参照する用

    void Update()
    {

        Animator anim = GetComponent<Animator>();
        // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
        velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            velocity.z += 1;
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))//方向キーを押しているとき(歩き)
        {
            moveSpeed = walkSpeed;//移動速度に歩き速度を代入
            if (Input.GetKey(KeyCode.LeftShift))//上記に加えさらにシフトキーを押しているとき(走り)
            {
                moveSpeed = runSpeed;//移動速度に走り速度を代入
            }
        }
        else //移動しないとき
        {
            moveSpeed = 0.0f;//移動速度を元に戻す()
        }

        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        anim.SetFloat("Speed", moveSpeed);//animatorにmoveSpeedを渡してSpeedに応じてアニメーション遷移

        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {
            // プレイヤーの回転(transform.rotation)の更新
            // 無回転状態のプレイヤーのZ+方向(後頭部)を、
            // カメラの水平回転(refCamera.hRotation)で回した移動の反対方向(-velocity)に回す回転に段々(applySpeedずつ)近づけます
            transform.rotation = Quaternion.Slerp(transform.rotation,//開始地点(今の地点)
                                                  Quaternion.LookRotation(refCamera.hRotation * velocity),//終了地点(カメラの水平方向の前方向とキャラの向きから算出)
                                                  applySpeed);//振り向き速度

            // プレイヤーの位置(transform.position)の更新
            // カメラの水平回転(refCamera.hRotation)で回した移動方向(velocity)を足し込みます
            transform.position += refCamera.hRotation * velocity;
        }
    }
}
