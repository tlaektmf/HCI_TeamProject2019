using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini3_PlayerController : MonoBehaviour
{
    //오브젝트 사이즈 변경
    GameObject mevil;
    GameObject mcastle;
    GameObject mroad;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       
        this.mevil = GameObject.Find("evil");
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
        mevil.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        mcastle.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        mroad.transform.Translate(0, -0.05f, 0);
    }
}
