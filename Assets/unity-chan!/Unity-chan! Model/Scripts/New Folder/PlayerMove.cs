using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Rigidbodyを変数に入れる
    Rigidbody rb;
    //移動スピード
    public float speed = 7f;
    //ジャンプ力
    public float thrust = 200;
    //Animatorを入れる変数
    private Animator animator;
    //ユニティちゃんの位置を入れる
    Vector3 playerPos;
    //地面に接触しているか否か
    bool ground;

    float x;
    float z;

    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        //ユニティちゃんのAnimatorにアクセスする
        animator = GetComponent<Animator>();
        //ユニティちゃんの現在より少し前の位置を保存
        playerPos = transform.position;
    }

    void Update()
    {
        //地面に接触していると作動する
        if (ground)
        {
            //A・Dキー、←→キーで横移動
            x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

            //W・Sキー、↑↓キーで前後移動
            z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

            //現在の位置＋入力した数値の場所に移動する
            rb.MovePosition(transform.position + new Vector3(x, 0, z));

            //ユニティちゃんの最新の位置から少し前の位置を引いて方向を割り出す
            Vector3 direction = transform.position - playerPos;

            //移動距離が少しでもあった場合に方向転換
            if (direction.magnitude > 0.01f)
            {
                //directionのX軸とZ軸の方向を向かせる
                transform.rotation = Quaternion.LookRotation(new Vector3
                    (direction.x, 0, direction.z));
                //走るアニメーションを再生
                animator.SetBool("Running", true);
            }
            else
            {
                //ベクトルの長さがない＝移動していない時は走るアニメーションはオフ
                animator.SetBool("Running", false);
            }

            //ユニティちゃんの位置を更新する
            playerPos = transform.position;

            //スペースキーやゲームパッドの3ボタンでジャンプ
            if (Input.GetButton("Jump"))
            {
                //thrustの分だけ上方に力がかかる
                rb.AddForce(transform.up * thrust);
                //速度が出ていたら前方と上方に力がかかる
                if (rb.velocity.magnitude > 0)
                    rb.AddForce(transform.forward * thrust + transform.up * thrust);
            }
        }
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * z + Camera.main.transform.right * x;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * speed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    //Planに触れている間作動
    void OnCollisionStay(Collision col)
    {
        ground = true;
        //ジャンプのアニメーションをオフにする
        animator.SetBool("Jumping", false);
    }

    //Planから離れると作動
    void OnCollisionExit(Collision col)
    {
        ground = false;
        //ジャンプのアニメーションをオンにする
        animator.SetBool("Jumping", true);
    }
}