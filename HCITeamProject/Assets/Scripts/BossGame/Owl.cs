using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour {
    Animator anim;                  // Animator
    Transform chkPoint;             // Check Point

    float moveSpeed = 7f;           // 이동 속도
    float jumpSpeed = 10f;          // 점프 속도
    float gravity = 19f;            // 중력

    Vector3 moveDir;                // 이동 방향
    private Touch tempTouchs;   //스마트폰터치 방향
    bool isDead = false;            // 사망?
    bool isPhone = false;    //스마트폰쓰니?
    bool start = false; //처음에 나뭇가지 정보 넣을때
    bool t = true;
    Vector3 beforeBranch;   //방금 점프한 나뭇가지 정보

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
        if (t)
        {
            CheckBranch();      // 나뭇가지 조사
            MoveOwl();          // 올빼미 이동
        }
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
                moveDir.x = -10.0f*moveSpeed;
            }
            else if (touchPos.x >= Screen.width / 2)
            {
                //오른쪽
                moveDir.x = 10.0f * moveSpeed;
            }
            moveDir.y -= gravity * Time.deltaTime;
        }
        else
        {
            //키보드일 때
            keyValue = Input.GetAxis("Horizontal");
            //print(keyValue);
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
        RaycastHit2D hit = Physics2D.Raycast(chkPoint.position, Vector2.down, 0.09f);

        // 디버그 출력
        Debug.DrawRay(chkPoint.position, Vector2.down * 1f, Color.blue);

        // 조사한 물체가 나뭇가지이면 점프 속도 설정

        if (hit.collider != null && hit.collider.tag == "Branch") {
            //print("점프할고야");
            if (!start)
            {
                beforeBranch = hit.point;
                start = true;
            }
            print(hit.point.y+" "+ beforeBranch.y+"");
            if (Mathf.Abs(hit.point.x-beforeBranch.x)<=0.01f &&Math.Abs(hit.point.y-beforeBranch.y)>=0.2f)
            {
                //y축은 다른데 x축은 같아. 그러면 바로 위에있는 거.
                print("점프반값");
                moveDir.y=jumpSpeed / 2 + 1f;
            }
            else
            {
                print("정상점프");
                moveDir.y = jumpSpeed;
            }
            beforeBranch = hit.point;
        }
    }
    IEnumerator wait()
    {
        print("쉬는시간");
        t = false;
        yield return new WaitForSeconds(1f);
        t = true;
        
        print("쉬는시간끄읕!");
    }
    // 충돌 판정 및 처리
    void OnTriggerEnter2D(Collider2D coll)
    {
        Transform other = coll.transform;

        switch (other.tag)
        {
            case "Bird":
                print("화살에 맞았어요");
                StartCoroutine("wait");
                other.SendMessage("DropBird");
                break;
            case "Gift":
                other.SendMessage("GetGift");
                break;
            case "Princess":
                //print("come on?");
                other.SendMessage("PrincessCollision");
                break;
        }
    } 
}

