using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mashroomController : MonoBehaviour
{
    GameObject mplayer;//케릭터 오브젝트
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.mplayer = GameObject.Find("player_man");//케릭터오브젝트
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;//Time.deltaTime : 앞프레임과 현재 프레임의 시간차이

        /*
       * 충돌판정
       */
        Vector2 mashroom_center = transform.position;//mashroom의 중심좌표
        Vector2 player_center = this.mplayer.transform.position;//캐릭터 중심좌표
        Vector2 dist = mashroom_center - player_center;
        float mashroom_radius = 0.5f;//mashroom 반경
        float player_radius = 1.0f;//플레이어 반경

        if (dist.magnitude < mashroom_radius + player_radius)
        {
            //충돌하는 경우, mashroom 소멸시킴
            Destroy(gameObject);

            //감독 스크립트에서 player와 object(mashroom)가 충돌했음을 전달
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().eatMashroom();
        }

    }
}
