using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini1_PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1.1f, 0, 0);//왼쪽으로 3만큼 이동
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1.1f, 0, 0);//오른쪽으로 3만큼 이동
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
