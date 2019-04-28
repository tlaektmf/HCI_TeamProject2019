using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini1_PlayerController : MonoBehaviour
{
    Vector2 min;
    Vector2 max;

    const float PLAYER_SIZE = 0.5f;
    const float PLAYER_SPEED = 0.1f;
    float BOUND_LEFT;
    float BOUND_RIGHT;

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

        // x 축 경계 설정
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        BOUND_LEFT = min.x + PLAYER_SIZE;
        BOUND_RIGHT = max.x - PLAYER_SIZE;


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
            
            if (checkBound(transform.position.x - PLAYER_SPEED) == true)
            {
                transform.Translate(-PLAYER_SPEED, 0, 0);//왼쪽으로  이동
                mbackground.transform.Translate(PLAYER_SPEED*0.2f, 0, 0);
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
            
            if (checkBound(transform.position.x + PLAYER_SPEED) ==true)
            {
                transform.Translate(PLAYER_SPEED, 0, 0);//오른쪽으로  이동
                mbackground.transform.Translate(-PLAYER_SPEED*0.2f, 0, 0);
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

    public bool checkBound(float next_x)
    {
        
        if (next_x> BOUND_RIGHT ||
            next_x < BOUND_LEFT)
        {
            return false;
        }
        else return true;
    }
}
