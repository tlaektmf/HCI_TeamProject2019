using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mini3_PlayerController : MonoBehaviour
{
    const float EVIL_SIZE= 0.005f;
    const float EVIL_MOVE = 0.01f;
    const float CASTLE_SIZE = 0.01f;
    const float ROAD_MOVE = 0.01f;
    //오브젝트 사이즈 변경
    GameObject evil_sleep;
    GameObject evil_awake;
    GameObject evil_open_eyes;

    GameObject mcastle;
    GameObject mroad;
    //열
    public Slider slider;

    private Animator anim;

    GameObject director;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;    //sprite

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
        spriteRenderer = mroad.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        //road 빨간색 배경
        if (EvilController.number == 2)
        {
            print("빨간 배경");
            spriteRenderer.sprite = sprites[1];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }

        
        if (Input.touchCount > 0)
        {
            if (Input.GetMouseButton(0))
            {
                //플레이어가 이동을 하지는 않고, 오브젝트들의 사이즈가 바뀜
                //transform.localScale += new Vector3(0.5f, 0.5f, 0);
                anim.SetBool("isRun", false);
                slider.value += 0.01f;
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
       

        if (EvilController.number==2)
        {
            //gameover
            director.GetComponent<mini3_GameDirector>().GameOver();
        }
        else
        {
            
            evil_awake.transform.localScale += new Vector3(EVIL_SIZE, EVIL_SIZE, 0);
            evil_sleep.transform.localScale += new Vector3(EVIL_SIZE, EVIL_SIZE, 0);
            evil_open_eyes.transform.localScale += new Vector3(EVIL_SIZE, EVIL_SIZE, 0);

            //위치 조정
            evil_awake.transform.Translate(EVIL_MOVE, -EVIL_MOVE, 0);
            evil_sleep.transform.Translate(EVIL_MOVE, -EVIL_MOVE, 0);
            evil_open_eyes.transform.Translate(EVIL_MOVE, -EVIL_MOVE, 0);

            mcastle.transform.localScale += new Vector3(CASTLE_SIZE, CASTLE_SIZE, 0);
            mroad.transform.Translate(0, -ROAD_MOVE, 0);
          
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
