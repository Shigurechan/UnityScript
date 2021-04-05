using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    bool isAttack1 = false; //�U��


    Vector3 moveVec;
    const float moveSpeed = 3.0f;   //�ړ����x
    
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
        //�L�[����
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

        //�}�E�X���N���b�N
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
        KeyInput();         //�L�[����        
        Move();             //�ړ�
        AnimationUpdate();  //�A�j���[�V����
        Attack();           //�U��

    }

    //�ړ�
    void Move()
    {
        //X�AZ�̃x�N�g���𓾂�
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = (cameraForward * moveVec.z) + (Camera.main.transform.right * moveVec.x);
        // �L�����N�^�[�̌�����i�s������
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        rb.velocity = moveSpeed * moveForward;

    }

    //�A�j���[�V�����X�V
    void AnimationUpdate()
    {
        anim.SetFloat("Speed",rb.velocity.magnitude);   //���s�A�j���[�V����

       
    }

    void FixedUpdate()
    {

    }



}
