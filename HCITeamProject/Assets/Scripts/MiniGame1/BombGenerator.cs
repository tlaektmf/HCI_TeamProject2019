using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    const float BOMB_SIZE = 0.05f;
    float BOUND_LEFT;
    float BOUND_RIGHT;
    Vector2 min;
    Vector2 max;

    bool isFinish = true;

    public GameObject mbombPrefab;//폭탄 프리팹을 넣을 변수(아울렛)
    GameObject mplayer;
    float span=2.0f;//default 폭탄 생성 주기
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        this.mplayer = GameObject.Find("player_man");//케릭터오브젝트

        //폭탄 생성 x 축 경계 설정
         min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
         max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        BOUND_LEFT = min.x+ BOMB_SIZE;
        BOUND_RIGHT = max.x - BOMB_SIZE;

       
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

                obj.transform.position = new Vector3(appear_x, max.y, 0);

                isFinish = false;
            }
        }



    }

    float setRandomSpan()
    {
        /*
        * 난이도 지정////////////////////////////////////////////////
        */
        //폭탄 생성 주기 설정
        if (SceneController.difficulty == "easy")
        {
            return Random.Range(1.0f, 1.5f);
          
        }
        else if (SceneController.difficulty == "normal")
        {
            return Random.Range(0.5f, 1.0f);
        }
        else if (SceneController.difficulty == "hard")
        {
            return Random.Range(0.7f, 1.0f);
        }
        ///////////////////////////////////////////////////////////////
        return Random.Range(0.5f, 1.0f);//defult

    }
}
