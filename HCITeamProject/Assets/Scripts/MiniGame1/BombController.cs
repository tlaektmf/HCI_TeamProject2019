﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    GameObject mplayer;//케릭터 오브젝트
    GameObject director;
    public GameObject explosion;
    float speed ;// 폭탄 낙하 속도

    // Start is called before the first frame update

    void Start()
    {
        this.director = GameObject.Find("mini1_GameDirector");
        this.mplayer = GameObject.Find("player_man");//케릭터오브젝트
       /// this.speed = Random.Range(0.1f, 5.0f);//default

        /*
        * 난이도 지정////////////////////////////////////////////////
        */
        //폭탄 낙하 속도 설정
        if (SceneController.difficulty == "easy")
        {
            this.speed = 0.1f;
        }
        else if (SceneController.difficulty == "middle")
        {
            this.speed = 0.1f;
        }
        else if (SceneController.difficulty == "hard")
        { 
            //this.speed = Random.Range(0.1f, 10.0f);
            this.speed = Random.Range(0.1f, 5.0f);
        }
        ///////////////////////////////////////////////////////////////

    }

    // Update is called once per frame
    void initPosition()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y,0.0f);
    }
    void Update()
    {

        transform.Translate(0, -1*speed* Time.deltaTime, 0);//0.1f의 속도만큼 낙하시킨다
        if (transform.position.y < -3.0f)
        {//장애물의 y위치(높이)가 -5.0 밑으로 가는경우(화면에서 사라지는 경우)
            
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            
            //gameObject.SetActive(false);
            
            Destroy(gameObject,0.1f);//폭탄을 삭제
            // initPosition();

        }

        /*
         * 충돌판정
         */
        Vector2 bomb_center = transform.position;//폭탄의 중심좌표
        Vector2 player_center = this.mplayer.transform.position;//캐릭터 중심좌표
        Vector2 dist = bomb_center - player_center;
        float bomb_radius = 0.3f;//폭탄 반경
        float player_radius = 0.3f;//플레이어 반경

        if (dist.magnitude < bomb_radius + player_radius)
        {
            //충돌하는 경우, 장애물을 소멸시킴
            Destroy(gameObject);
            SoundManager.Instance.Stop();
            SoundManager.Instance.PlayEffectWithPath("audio/common/gameover_tetris");
            //감독 스크립트에서 player와 object가 충돌했음을 전달
            director.GetComponent<mini1_GameDirector>().GameOver();
        }
    }
}
