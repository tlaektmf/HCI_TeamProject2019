using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    float BOUND_LEFT;
    float BOUND_RIGHT;
    bool isFinish = true;

    public GameObject mbombPrefab;//폭탄 프리팹을 넣을 변수(아울렛)
    GameObject mplayer;
    float span;//1초마다 1개씩 폭탄을 생성
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        span = 1.0f;//1초마다 1개씩 폭탄을 생성(초기설정)
        this.mplayer = GameObject.Find("player_man");//케릭터오브젝트
        BOUND_LEFT = 0.0f;
        BOUND_RIGHT = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        this.delta += Time.deltaTime;//Time.deltaTime : 앞프레임과 현재 프레임의 시간차이

        if (isFinish == false)
        {
            span = setRandomSpan();
            isFinish = true;
            Debug.Log("set new span: " + span);
        }
        else
        {
            if (this.delta > this.span)
            {
                this.delta = 0;
                GameObject obj = Instantiate(mbombPrefab) as GameObject;

                float appear_x = Random.Range(BOUND_LEFT, BOUND_RIGHT) ;//x좌표 범위 지정

                //Vector2 worldpos = new Vector2(appear_x, 1.0f);


                obj.transform.position = new Vector3(appear_x, 1.0f, 0);
                ///Vector2 worldpos = new Vector2(appear_x, 0.0f);
                ///obj.transform.position = Camera.main.WorldToScreenPoint(worldpos);

                isFinish = false;
            }
        }



    }

    float setRandomSpan()//폭탄이 떨어지는 속도 설정
    {
        return Random.Range(0.5f, 1);//0.5초~1초

    }
}
