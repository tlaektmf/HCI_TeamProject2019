using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Image 클래스 사용가능

public class EvilController : MonoBehaviour
{
    ///int EVIL_EMOTION_CNT = 3;
    ////public Sprite[] evilObj = new Sprite[3];

    GameObject mplayer;//케릭터 오브젝트

     GameObject evil_sleep;
    GameObject evil_awake;
    GameObject evil_open_eyes;

    float span = 1;
    float delta = 0;
    float total_time = 0;
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

    }

    // Update is called once per frame
    void Update()
    {
        if (this.total_time<=1)
        {
            evil_sleep.GetComponent<SpriteRenderer>().enabled = true;

        }

       
        this.delta += Time.deltaTime;//Time.deltaTime : 앞프레임과 현재 프레임의 시간차이
        this.total_time += Time.deltaTime;
        if (this.delta > this.span)//1초 후
        {
            this.delta = 0;
            int evilNum = (Random.Range(1, 99)%3)+1;
           Debug.Log(evilNum);
       

            switch (evilNum)
            {

                case 1:
                    evil_open_eyes.GetComponent<SpriteRenderer>().enabled = true;
                    evil_open_eyes.SetActive(true);

                    evil_awake.GetComponent<SpriteRenderer>().enabled = false;
                    evil_awake.SetActive(false);

                    evil_sleep.GetComponent<SpriteRenderer>().enabled = false;
                    evil_sleep.SetActive(false);

                    break;
                case 2:
                    evil_open_eyes.GetComponent<SpriteRenderer>().enabled = false;
                    evil_open_eyes.SetActive(false);

                    evil_awake.GetComponent<SpriteRenderer>().enabled = true;
                    evil_awake.SetActive(true);

                    evil_sleep.GetComponent<SpriteRenderer>().enabled = false;
                    evil_sleep.SetActive(false);

                 
                    break;
                case 3:
                    evil_open_eyes.GetComponent<SpriteRenderer>().enabled = false;
                    evil_open_eyes.SetActive(false);

                    evil_awake.GetComponent<SpriteRenderer>().enabled = false;
                    evil_awake.SetActive(false);

                    evil_sleep.GetComponent<SpriteRenderer>().enabled = true;
                    evil_sleep.SetActive(true);


                    break;
            }

        }

       

    }

}
