using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    GameObject mplayer;//케릭터 오브젝트
    GameObject director;

    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        this.mplayer = GameObject.Find("player_man_back");//케릭터오브젝트
    }

    // Update is called once per frame
    void Update()
    {
         crushDetect();
    }

    void crushDetect()
    {
        /*
        * 충돌판정
        */
        Vector2 castle_center = transform.position;//성의 중심좌표
        Vector2 player_center = this.mplayer.transform.position;//캐릭터 중심좌표
        Vector2 dist = castle_center - player_center;
        float castle_radius = 0.5f;//castle 반경
        float player_radius = 0.5f;//플레이어 반경

        if (dist.magnitude < castle_radius + player_radius)
        {
            //충돌하는 경우
            //감독 스크립트에서 player와 object가 충돌했음을 전달
           /// Debug.Log("충돌");
            director.GetComponent<GameDirector>().GameOver();
        }
        else
        {
           /// Debug.Log("충돌하지않음");
        }
    }
}
