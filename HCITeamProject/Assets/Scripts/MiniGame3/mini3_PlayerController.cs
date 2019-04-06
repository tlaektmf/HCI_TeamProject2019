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

    // Start is called before the first frame update
    void Start()
    {

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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //플레이어가 이동을 하지는 않고, 오브젝트들의 사이즈가 바뀜
            //transform.localScale += new Vector3(0.5f, 0.5f, 0);
            anim.SetBool("isRun", false);
            UpButton();
        }else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetBool("isRun", true);
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
        evil_awake.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        evil_sleep.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        evil_open_eyes.transform.localScale += new Vector3(0.05f, 0.05f, 0);

        mcastle.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        mroad.transform.Translate(0, -0.05f, 0);
    }
}
