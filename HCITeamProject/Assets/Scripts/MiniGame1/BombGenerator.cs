using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    int BOUND_LEFT = -2;
    int BOUNT_RIGHT = 2;
    bool isFinish = true;

    public GameObject mbombPrefab;//폭탄 프리팹을 넣을 변수(아울렛)
    float span;//1초마다 1개씩 폭탄을 생성
   /// public float speed = 1.0f;//폭탄의 속도
    float delta = 0;
    ///Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        span = 1.0f;//1초마다 1개씩 폭탄을 생성(초기설정)
       /// rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        this.delta += Time.deltaTime;//Time.deltaTime : 앞프레임과 현재 프레임의 시간차이

        if (isFinish == false)
        {
            span = setRandomSpan();
            isFinish = true;
            Debug.Log("set new span: " + span);
        }
        else
        {
            if (this.delta > this.span)
            {
                this.delta = 0;
                GameObject obj = Instantiate(mbombPrefab) as GameObject;
                ///this.speed = Random.Range(0.5f, 1.0f);
                
                
                ///GameObject obj2 = Instantiate(mbombPrefab) as GameObject;
                ///GameObject obj3 = Instantiate(mbombPrefab) as GameObject;
                //float random_mass=Random.Range(0.3f, 1);
                //obj.GetComponent<Rigidbody>().mass = random_mass;
                int appear_x = Random.Range(BOUND_LEFT, BOUNT_RIGHT);//x좌표 범위 지정
                ///int appear_x2= Random.Range(BOUND_LEFT, BOUNT_RIGHT);//x좌표 범위 지정
               /// int appear_x3= Random.Range(BOUND_LEFT, BOUNT_RIGHT);//x좌표 범위 지정
                obj.transform.position = new Vector3(appear_x, 7, 0);
                ///obj2.transform.position = new Vector3(appear_x2, 7, 0);
               /// obj3.transform.position = new Vector3(appear_x3, 7, 0);
                isFinish = false;
            }
        }



    }

    float setRandomSpan()//폭탄이 떨어지는 속도 설정
    {
        return Random.Range(0.5f, 1);//0.5초~1초

    }
}
