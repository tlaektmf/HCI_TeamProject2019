using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    GameObject mplayer;//케릭터 오브젝트
    GameObject director;

    float []speedArr = { 1.0f,0.1f };
    float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.Find("mini1_GameDirector");
        this.mplayer = GameObject.Find("player_man");//케릭터오브젝트
        //this.speed = Random.Range(0.1f, 10.0f);
       this.speed = speedArr[Random.Range(1,100)%2];
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0, -1*speed* Time.deltaTime, 0);//0.1f의 속도만큼 낙하시킨다
        Debug.Log("speeed"+speed);
        if (transform.position.y < -5.0f)
        {//장애물의 y위치(높이)가 -5.0 밑으로 가는경우(화면에서 사라지는 경우)

            Destroy(gameObject);//폭탄을 삭제

        }

        /*
         * 충돌판정
         */
        Vector2 bomb_center = transform.position;//폭탄의 중심좌표
        Vector2 player_center = this.mplayer.transform.position;//캐릭터 중심좌표
        Vector2 dist = bomb_center - player_center;
        float bomb_radius = 0.5f;//폭탄 반경
        float player_radius = 0.5f;//플레이어 반경

        if (dist.magnitude < bomb_radius + player_radius)
        {
            //충돌하는 경우, 장애물을 소멸시킴
            Destroy(gameObject);

            //감독 스크립트에서 player와 object가 충돌했음을 전달
            director.GetComponent<mini1_GameDirector>().GameOver();
        }
    }
}
