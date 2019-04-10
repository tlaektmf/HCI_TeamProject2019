using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour {
    Animator anim;                  // Animator
    Transform chkPoint;             // Check Point

    float moveSpeed = 8f;           // 이동 속도
    float jumpSpeed = 10f;          // 점프 속도
    float gravity = 19f;            // 중력

    Vector3 moveDir;                // 이동 방향
    private Touch tempTouchs;   //스마트폰터치 방향
    bool isDead = false;            // 사망?
    bool isPhone = false;    //스마트폰쓰니?

    Transform beforeBranch;   //방금 점프한 나뭇가지 정보

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        chkPoint = transform.Find("CheckPoint");
        if (Application.platform == RuntimePlatform.Android)
        {
            isPhone = true;
        }
    }
    // Update is called once per frame
    void Update () {
        if (isDead) return;
        CheckBranch();      // 나뭇가지 조사
        MoveOwl();          // 올빼미 이동
    }

    // 올빼미 이동
    void MoveOwl () {
        // 올빼미가 화면 아래를 벗어났나?
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        if (pos.y < -100) {
            isDead = true;
            // GameManager에 통지
            FindObjectOfType<GameManager>().SendMessage("GameOver");
            return;
        }

        // 키 입력
        float keyValue=0.0f;
        
        if (isPhone)
        {
            Vector3 touchPos = Input.GetTouch(0).position;  //터치좌표를 가져옴.
            if (touchPos.x <= Screen.width / 2)
            {
                //왼쪽
                moveDir.x = -Vector3.right.x*moveSpeed;
            }
            else if (touchPos.x >= Screen.width / 2)
            {
                //오른쪽
                moveDir.x = Vector3.right.x * moveSpeed;
            }
            // 화면의 가장자리인지 조사
            if ((keyValue < 0 && pos.x < 40) ||
                (keyValue > 0 && pos.x > Screen.width - 40))
            {
                moveDir.x = 0;
            }
            else
            {
                //화면의 가장자리가 아니라면 실행

                // 중력
                moveDir.y -= gravity * Time.deltaTime;

                // 이동
                transform.Translate(moveDir * Time.deltaTime);

                // 올빼미 애니메이션
                anim.SetFloat("velocity", moveDir.y);
            }
        }
        else
        {
            //키보드일 때
            keyValue = Input.GetAxis("Horizontal");
            print(keyValue);
            // 화면의 가장자리인지 조사
            if ((keyValue < 0 && pos.x < 40) ||
                (keyValue > 0 && pos.x > Screen.width - 40))
            {
                keyValue = 0;
            }
            moveDir.x = keyValue * moveSpeed;

            // 중력
            moveDir.y -= gravity * Time.deltaTime;

            // 이동
            transform.Translate(moveDir * Time.deltaTime);

            // 올빼미 애니메이션
            anim.SetFloat("velocity", moveDir.y);
        }
    }

    // 나뭇가지 판정
    void CheckBranch () {
        // CheckPoint에서 아래쪽으로 0.2m 이내 조사
        RaycastHit2D hit = Physics2D.Raycast(chkPoint.position, Vector2.down, 0.1f);

        // 디버그 출력
        Debug.DrawRay(chkPoint.position, Vector2.down * 1f, Color.blue);

        // 조사한 물체가 나뭇가지이면 점프 속도 설정
        beforeBranch = hit.transform;

        if (hit.collider != null && hit.collider.tag == "Branch") {
            //print("점프할고야");
            moveDir.y = jumpSpeed;
            //if (beforeBranch.transform == hit.transform)
            //{
            //    이전의 나뭇가지를 또 밟은 것
            //    moveDir.y = jumpSpeed;
            //}
            //else
            //{
            //    새로운 나뭇가지를 밟은 것
            //    /*1) */
            //}

        }
        else
        {
            //print("놉 점프");
        }
    }
    // 충돌 판정 및 처리
    void OnTriggerEnter2D(Collider2D coll)
    {
        Transform other = coll.transform;

        switch (other.tag)
        {
            case "Bird":
                other.SendMessage("DropBird");
                break;
            case "Gift":
                other.SendMessage("GetGift");
                break;
            case "Princess":
                print("come on?");
                other.SendMessage("PrincessCollision");
                break;
        }
    }
}

