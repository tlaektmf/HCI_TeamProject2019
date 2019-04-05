using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mashroomGenerator : MonoBehaviour
{
    // Start is called before the first frame update

   /// bool isFinish = true;
    int BOUND_LEFT = -2;
    int BOUNT_RIGHT = 2;

    public GameObject mmashPrefab;//mashroom 프리팹을 넣을 변수(아울렛)
    float span;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        span = 8.0f;//1초마다 1개씩 mashroom을 생성(초기설정)
    }

    // Update is called once per frame
    void Update()
    {

        this.delta += Time.deltaTime;//Time.deltaTime : 앞프레임과 현재 프레임의 시간차이

        //if (isFinish == false)
        //{
        //    span = setRandomSpan();
        //    isFinish = true;
        //    Debug.Log("set new span: " + span);
        //}
        //else
        //{
            if (this.delta > this.span)
            {
                this.delta = 0;
                GameObject obj = Instantiate(mmashPrefab) as GameObject;
                int appera_x = Random.Range(BOUND_LEFT, BOUNT_RIGHT);//x좌표 범위 지정
                obj.transform.position = new Vector3(appera_x, 7, 0);
                ///isFinish = false;
            }
       // }



    }

    float setRandomSpan()//mashroom이 떨어지는 속도 설정
    {
        return Random.Range(0.5f, 1);//0.5초~1초

    }
}
