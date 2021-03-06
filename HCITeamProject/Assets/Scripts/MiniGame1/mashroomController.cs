﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mashroomController : MonoBehaviour
{
    GameObject mplayer;//케릭터 오브젝트

    float MUSHROOM_SPEED = 0.05f;//default 버섯 낙하 속도

    // Start is called before the first frame update
    void Start()
    {
        this.mplayer = GameObject.Find("player_man");//케릭터오브젝트
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(0, -MUSHROOM_SPEED, 0);//0.1f의 속도만큼 낙하시킨다

        if (transform.position.y < -5.0f)
        {//장애물의 y위치(높이)가 -5.0 밑으로 가는경우(화면에서 사라지는 경우)

            Destroy(gameObject);//폭탄을 삭제

        }

        /*
       * 충돌판정
       */
        Vector2 mashroom_center = transform.position;//mashroom의 중심좌표
        Vector2 player_center = this.mplayer.transform.position;//캐릭터 중심좌표
        Vector2 dist = mashroom_center - player_center;
        float mashroom_radius = 0.3f;//mashroom 반경
        float player_radius = 0.3f;//플레이어 반경

        if (dist.magnitude < mashroom_radius + player_radius)
        {
            //충돌하는 경우, mashroom 소멸시킴
            Destroy(gameObject);

            //감독 스크립트에서 player와 object(mashroom)가 충돌했음을 전달
            GameObject director = GameObject.Find("mini1_GameDirector");
            director.GetComponent<mini1_GameDirector>().eatMashroom();
        }

    }
}
