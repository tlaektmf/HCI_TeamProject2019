using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Image 클래스 사용가능

public class EvilController : MonoBehaviour
{
    GameObject mplayer;//케릭터 오브젝트
    float span = 2.0f;//2초마다 이미지 변경
    float delta = 0;
   // bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        this.mplayer = GameObject.Find("player_man_back");//케릭터오브젝트
    }

    // Update is called once per frame
    void Update()
    {
        //2초마다 evil의 모양을 변경 시킴
        this.delta += Time.deltaTime;//Time.deltaTime : 앞프레임과 현재 프레임의 시간차이
        //(여리 추가) - 실눈 뜬 모습은 cat2, 완전히 잠에서 깬 모습은 cat3
        //if (this.delta > this.span)//2초 후
        //{
        //    this.delta = 0;
        //    int emotionNum = Random.Range(1, 3);
        //    string imgPath = "evil_emotion" + emotionNum+".png";
        //    Debug.Log(imgPath);
        //    gameObject.GetComponent<Image>().sprite = Resources.Load(imgPath, typeof(Sprite)) as Sprite;

        //}

        /*
         * 충돌판정
         */
        Vector2 evil_center = transform.position;//evil의 중심좌표
        Vector2 player_center = this.mplayer.transform.position;//캐릭터 중심좌표
        Vector2 dist = evil_center - player_center;
        float evil_radius = 0.5f;//evil 반경
        float player_radius = 1.0f;//플레이어 반경

        if (dist.magnitude < evil_radius + player_radius)
        {
            //충돌하는 경우, evil 소멸시킴, 성 문이 보이도록 함
            Destroy(gameObject);

            //감독 스크립트에서 player와 object가 충돌했음을 전달
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().miniGame3Clear();
        }

    }
}
