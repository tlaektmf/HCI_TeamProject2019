using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini3_PlayerController : MonoBehaviour
{
    //오브젝트 사이즈 변경
    GameObject evil_sleep;
    GameObject evil_awake;
    GameObject evil_open_eyes;

    GameObject mcastle;
    GameObject mroad;
    private Animator anim;

    GameObject director;

    ///float BOUND_SIZE = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.Find("mini3_GameDirector");

        this.evil_open_eyes = GameObject.Find("evil_open_eyes");
        this.evil_sleep = GameObject.Find("evil_sleep");
        this.evil_awake = GameObject.Find("evil_awake");

        this.mcastle = GameObject.Find("castle");
        this.mroad = GameObject.Find("road");
        anim = GetComponent<Animator>();
        anim.SetBool("isRun", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetMouseButton(0))
            {
                //플레이어가 이동을 하지는 않고, 오브젝트들의 사이즈가 바뀜
                //transform.localScale += new Vector3(0.5f, 0.5f, 0);
                anim.SetBool("isRun", false);
                UpButton();
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                anim.SetBool("isRun", true);
            }
        }

    }

    /*
 사용자 정의 함수
 */
    public void UpButton()
    {
        ////if(evil_open_eyes.activeSelf == true)
        ////{
        ////    evil_open_eyes.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        ////}
        ////if (evil_sleep.activeSelf == true)
        ////{
        ////    evil_sleep.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        ////}
        ////if (evil_awake.activeSelf == true)
        ////{
        ////    evil_awake.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        ////}
        ///

        if (evil_sleep.activeSelf == false)
        {
            //gameover
            director.GetComponent<mini3_GameDirector>().GameOver();
        }
        else
        {
            //사이즈 조정
            //if (evil_awake.transform.localScale.y<BOUND_SIZE)
            //{
            //    evil_awake.transform.localScale += new Vector3(0.05f, 0.05f, 0);
            //    evil_sleep.transform.localScale += new Vector3(0.05f, 0.05f, 0);
            //    evil_open_eyes.transform.localScale += new Vector3(0.05f, 0.05f, 0);
            //}

            evil_awake.transform.localScale += new Vector3(0.05f, 0.05f, 0);
            evil_sleep.transform.localScale += new Vector3(0.05f, 0.05f, 0);
            evil_open_eyes.transform.localScale += new Vector3(0.05f, 0.05f, 0);

            //위치 조정
            evil_awake.transform.Translate(0.1f, -0.1f, 0);
            evil_sleep.transform.Translate(0.1f, -0.1f, 0);
            evil_open_eyes.transform.Translate(0.1f, -0.1f, 0);

            mcastle.transform.localScale += new Vector3(0.1f, 0.1f, 0);
            mroad.transform.Translate(0, -0.05f, 0);
            ///Debug.Log(evil_awake.transform.localScale);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject == mcastle)
        {
            //감독 스크립트에서 player와 object가 충돌했음을 전달
            Debug.Log("충돌");
            GameObject director = GameObject.Find("mini3_GameDirector");
            director.GetComponent<mini3_GameDirector>().miniGame3Clear();
        }
    }
}
