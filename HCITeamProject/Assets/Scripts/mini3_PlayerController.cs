using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini3_PlayerController : MonoBehaviour
{
    //오브젝트 사이즈 변경
    GameObject mevil;
    GameObject mcastle;
    GameObject mroad;

    // Start is called before the first frame update
    void Start()
    {
        this.mevil = GameObject.Find("evil_emotion0");
        this.mcastle = GameObject.Find("castle");
        this.mroad = GameObject.Find("road");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //플레이어가 이동을 하지는 않고, 오브젝트들의 사이즈가 바뀜
            //transform.localScale += new Vector3(0.5f, 0.5f, 0);
            UpButton();
        }

    }

    /*
 사용자 정의 함수
 */
    public void UpButton()
    {
        mevil.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        mcastle.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        mroad.transform.Translate(0, -0.1f, 0);
    }
}
