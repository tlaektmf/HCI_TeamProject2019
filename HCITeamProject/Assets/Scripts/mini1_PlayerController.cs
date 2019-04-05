using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini1_PlayerController : MonoBehaviour
{
    GameObject mbackground;
    private Animator anim;

    /*Animation 작동 원리
     * isStay가 true이고, isLeft가 false일 경우, isRight가 false일 경우 = 정적인 모습
     * isStay가 false이고, isLeft가 true일경우 = 왼쪽으로 움직이는 모습
     * isStay가 false이고, isRight가 true일 경우 = 오른쪽으로 움직이는 모습
     * 
     */
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("isStay", true);
        anim.SetBool("isLeft", false);
        anim.SetBool("isRight", false);
        this.mbackground = GameObject.Find("minigame1_background");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isStay", false);
            anim.SetBool("isLeft", true);
            transform.Translate(-0.1f, 0, 0);//왼쪽으로 3만큼 이동
            mbackground.transform.Translate(0.3f, 0, 0);
            
        }else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("isStay", true);
            anim.SetBool("isLeft", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isStay", false);
            anim.SetBool("isRight", true);
            transform.Translate(0.1f, 0, 0);//오른쪽으로 3만큼 이동
            mbackground.transform.Translate(-0.3f, 0, 0);
        }else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("isStay", true);
            anim.SetBool("isRight", false);
        }
    }

    /*
     사용자 정의 함수
     */
    public void LButtonDown()
    {
        transform.Translate(-1.1f, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(1.1f, 0, 0);
    }
    
}
