using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    bool isAttack1 = false; //攻撃


    Vector3 moveVec;
    const float moveSpeed = 3.0f;   //移動速度
    
    Rigidbody rb;   
    Animator anim;  


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        moveVec = new Vector3(0,0,0);
    }

    void KeyInput()
    {
        //キー入力
        if (Input.GetKey(KeyCode.W))
        {
            moveVec.z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVec.z = -1;
        }
        else
        {
            moveVec.z = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVec.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveVec.x = 1;
        }
        else
        {
            moveVec.x = 0;
        }

        //マウス左クリック
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }

    }

    void Attack()
    {
        if(anim.GetBool("Attack") == true)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();         //キー入力        
        Move();             //移動
        AnimationUpdate();  //アニメーション
        Attack();           //攻撃

    }

    //移動
    void Move()
    {
        //X、Zのベクトルを得る
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = (cameraForward * moveVec.z) + (Camera.main.transform.right * moveVec.x);
        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        rb.velocity = moveSpeed * moveForward;

    }

    //アニメーション更新
    void AnimationUpdate()
    {
        anim.SetFloat("Speed",rb.velocity.magnitude);   //歩行アニメーション

       
    }

    void FixedUpdate()
    {

    }



}
