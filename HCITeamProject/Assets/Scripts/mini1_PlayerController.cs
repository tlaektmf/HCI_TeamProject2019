using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini1_PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    int BOUND_LEFT = -3;
    int BOUNT_RIGHT = 3;
    GameObject mbackground;
    void Start()
    {
        this.mbackground = GameObject.Find("minigame1_background");//케릭터오브젝트
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldpos.x < 0f) worldpos.x = 0.1f;
        if (worldpos.y < 0f) worldpos.y = 0f;
        if (worldpos.x > 1f) worldpos.x = 0.9f;
        if (worldpos.y > 1f) worldpos.y = 1f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1.1f, 0, 0);//왼쪽으로 3만큼 이동
            mbackground.transform.Translate(0.1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1.1f, 0, 0);//오른쪽으로 3만큼 이동
            mbackground.transform.Translate(-0.1f, 0, 0);
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
