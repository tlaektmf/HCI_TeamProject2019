using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Image 클래스 사용가능

public class EvilController : MonoBehaviour
{

    
    GameObject mplayer;//케릭터 오브젝트
    GameObject evil_sleep;
    GameObject evil_awake;
    GameObject evil_open_eyes;

    float FREQ_IMG = 2.0f;// 이미지 변경 속도
    float TIME_TYPE2_APPEAR = 5.0f;//default 실눈 뜬 고양이 지속 시간 조절
    float TIME_TYPE3_APPEAR = 2.0f;
    float delta = 0;
    float time;
int evilNum;
    bool flag;
    public static int number;

    // Start is called before the first frame update
    void Start()
    {
        this.mplayer = GameObject.Find("player_man_back");//케릭터오브젝트
        this.evil_open_eyes = GameObject.Find("evil_open_eyes");
        this.evil_sleep = GameObject.Find("evil_sleep");
        this.evil_awake = GameObject.Find("evil_awake");

        evil_awake.GetComponent<SpriteRenderer>().enabled = false;
        evil_sleep.GetComponent<SpriteRenderer>().enabled = false;
        evil_open_eyes.GetComponent<SpriteRenderer>().enabled = false;

        /*
       * 난이도 지정////////////////////////////////////////////////
       */
        //실눈뜬 고양이 등장 속도 조절

        if (SceneController.difficulty == "easy")
        {
            this.TIME_TYPE2_APPEAR = 3.0f;

        }
        else if (SceneController.difficulty == "middle")
        {
            this.TIME_TYPE2_APPEAR = 2.5f;
        }
        else if (SceneController.difficulty == "hard")
        {
            this.TIME_TYPE2_APPEAR = 2.0f;
        }
        ///////////////////////////////////////////////////////////////
        evilNum = -1;
        flag = true;
        this.time = Random.Range(2, 5);

    }

    // Update is called once per frame
    void Update()
    {

        
        this.delta += Time.deltaTime;//Time.deltaTime : 앞프레임과 현재 프레임의 시간차이

        Debug.Log("time  "+time+"  evilnum: " + evilNum + "  delta    " + delta + "  time.deltatime  " + Time.deltaTime);
        if (flag == true)
        {

            flag = false;
            waitTime();

        }

        if (evilNum == 0 && delta >= time)//자고있음
        {
            delta = 0;
            flag = true;
            time= Random.Range(2, 7);
        }
        if (evilNum == 1 && delta >= TIME_TYPE2_APPEAR)//실눈
        {
            delta = 0;
            flag = true;
        }
        if (evilNum == 2 && delta >= TIME_TYPE3_APPEAR)//눈다뜸
        {
            delta = 0;
            flag = true;
        }



    }

    public void waitTime()
    {

        /*
        * 난이도 지정////////////////////////////////////////////////
        */

        evilNum = (evilNum + 1) % 3;
        number = evilNum;
        Debug.Log("evilnum " + evilNum);

        switch (evilNum)
        {

            case 1://실눈
                evil_open_eyes.GetComponent<SpriteRenderer>().enabled = true;
                //evil_open_eyes.SetActive(true);

                evil_awake.GetComponent<SpriteRenderer>().enabled = false;
                //evil_awake.SetActive(false);

                evil_sleep.GetComponent<SpriteRenderer>().enabled = false;
                //evil_sleep.SetActive(false);



                break;
            case 2://눈다뜸
                evil_open_eyes.GetComponent<SpriteRenderer>().enabled = false;
                //evil_open_eyes.SetActive(false);

                evil_awake.GetComponent<SpriteRenderer>().enabled = true;
                //evil_awake.SetActive(true);

                evil_sleep.GetComponent<SpriteRenderer>().enabled = false;
                //evil_sleep.SetActive(false);


                break;
            case 0://자고있음
                evil_open_eyes.GetComponent<SpriteRenderer>().enabled = false;
                //evil_open_eyes.SetActive(false);

                evil_awake.GetComponent<SpriteRenderer>().enabled = false;
                //evil_awake.SetActive(false);

                evil_sleep.GetComponent<SpriteRenderer>().enabled = true;
                //evil_sleep.SetActive(true);


                break;

        }


    }


}
