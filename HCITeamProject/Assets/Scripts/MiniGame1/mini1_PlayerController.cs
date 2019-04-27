using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini1_PlayerController : MonoBehaviour
{
    int MOVE_BACKGROUND = 2;
    int OUT_BOUND_MIN = 0;
    int OUT_BOUND_MAX = 1;
    GameObject mbackground;
    private Animator anim;
    int move_back_flag;//0,1,2
    
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
        //this.move_back_flag = MOVE_BACKGROUND;//초기에는 배경을 이동
    }

    // Update is called once per frame
    void Update()
    {


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Vector3 tpos = Input.GetTouch(0).position;//터치할 좌표

        if (Input.GetKey(KeyCode.LeftArrow))
        //if(tpos.x<=Screen.width/2)//왼쪽
        {
            anim.SetBool("isStay", false);
            anim.SetBool("isLeft", true);
            transform.Translate(-0.1f, 0, 0);//왼쪽으로 3만큼 이동
            if (checkBound() == MOVE_BACKGROUND)
            {
                mbackground.transform.Translate(0.05f, 0, 0);
            }
            
            
        }
        //else if (tpos.x <= Screen.width / 2)
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("isStay", true);
            anim.SetBool("isLeft", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        //if (tpos.x >Screen.width / 2)
        {
            anim.SetBool("isStay", false);
            anim.SetBool("isRight", true);
            transform.Translate(0.1f, 0, 0);//오른쪽으로 3만큼 이동
            if (checkBound()==MOVE_BACKGROUND)
            {
                mbackground.transform.Translate(-0.05f, 0, 0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        // else if (tpos.x > Screen.width / 2)
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
   
    public int checkBound()
    {
        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);

        if (worldpos.x < 0f)
        {
            ///worldpos.x = 0.1f;
            move_back_flag = OUT_BOUND_MIN;
        }
        //if (worldpos.y < 0f)
        //{
        //    worldpos.y = 0f;
        //}
        else if (worldpos.x > 1f)
        {
            ///worldpos.x = 0.9f;
            move_back_flag = OUT_BOUND_MAX;
        }
        //if (worldpos.y > 1f)
        //{
        //    worldpos.y = 1f;
        //}
        else if (worldpos.x > 0.1f && worldpos.x < 0.9f)
        {
            move_back_flag = MOVE_BACKGROUND;
        }

        if (move_back_flag == OUT_BOUND_MIN) worldpos.x = 0.1f;
        if (move_back_flag == OUT_BOUND_MAX) worldpos.x = 0.9f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);

        Debug.Log(move_back_flag);

        return move_back_flag;
        
    }
    
}
