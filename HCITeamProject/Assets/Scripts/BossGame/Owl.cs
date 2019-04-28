using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour {
    Animator anim;                  // Animator
    Transform chkPoint;             // Check Point

    float moveSpeed = 7f;           // 이동 속도    //default:7f
    float jumpSpeed = 10f;          // 점프 속도
    float gravity = 13f;            // 중력

    Vector3 moveDir;                // 이동 방향
    private Touch tempTouchs;   //스마트폰터치 방향
    bool isDead = false;            // 사망?
    bool start = false; //처음에 나뭇가지 정보 넣을때
    bool t = true;
    Vector3 beforeBranch;   //방금 점프한 나뭇가지 정보
    float beforetime;
    bool touch_p = false;
    float KeyYalue=0.0f;

    // Use this for initialization
    void Start () {
        moveDir = new Vector3(0,0,0);
        anim = GetComponent<Animator>();
        chkPoint = transform.Find("CheckPoint");
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
        //Vector3 touchPos = Input.GetTouch(0).position;  //터치좌표를 가져옴.
        bool touching = false;
        if (Input.GetMouseButton(0))
        {
            
            touching = true;
            KeyYalue += 1.4f * Time.deltaTime;
            Vector3 touchPos = Input.mousePosition;  //터치좌표를 가져옴.
            if (touchPos.x <= Screen.width / 2)
            {
                //왼쪽
                moveDir.x = -KeyYalue * moveSpeed;
            }
            else if (touchPos.x >= Screen.width / 2)
            {
                //오른쪽
                moveDir.x = KeyYalue * moveSpeed;
            }
        }

        if (touching == false)
        {
            KeyYalue = 0.0f;
        }
        
        // 화면의 가장자리인지 조사
        

        moveDir.y -= gravity * Time.deltaTime;
        transform.Translate(moveDir * Time.deltaTime);
        anim.SetFloat("velocity", moveDir.y);
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
            if (Mathf.Abs(hit.point.x-beforeBranch.x)<=0.01f &&Math.Abs(hit.point.y-beforeBranch.y)>=0.2f)
            {
                //y축은 다른데 x축은 같아. 그러면 바로 위에있는 거.
                print("점프반값");
                moveDir.y=jumpSpeed / 2 + 1f;
                SoundManager.Instance.PlayEffectWithPath("audio/boss/jump");
            }
            else
            {
                print("정상점프");
                moveDir.y = jumpSpeed;
                SoundManager.Instance.PlayEffectWithPath("audio/boss/jump");
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
                StartCoroutine("wait");
                other.SendMessage("DropBird");
                SoundManager.Instance.PlayEffectWithPath("audio/boss/arrow");
                break;
            case "Gift":
                other.SendMessage("GetGift");
                break;
            case "Princess":
                other.SendMessage("PrincessCollision");
                break;
        }
    } 
}

