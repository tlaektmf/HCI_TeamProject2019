using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mashroomGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    int BOUND_LEFT = -2;
    int BOUNT_RIGHT = 2;
    public GameObject mmashPrefab;//mashroom 프리팹을 넣을 변수(아울렛)
    float span=10.0f;//default; 버섯 생성 주기
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*
         * 난이도 지정////////////////////////////////////////////////
         */
        //버섯 생성 주기 설정
        if (SceneController.difficulty == "easy")
        {
            span = 8.0f;//1초마다 1개씩 mashroom을 생성(초기설정)
        }else if (SceneController.difficulty == "middle")
        {
            span = 10.0f;//1초마다 1개씩 mashroom을 생성(초기설정)
        }else if (SceneController.difficulty == "hard")
        {
            span = 20.0f;//1초마다 1개씩 mashroom을 생성(초기설정)
        }
        ///////////////////////////////////////////////////////////////
    }

    // Update is called once per frame
    void Update()
    {

        this.delta += Time.deltaTime;//Time.deltaTime : 앞프레임과 현재 프레임의 시간차이

            if (this.delta > this.span)
            {
                this.delta = 0;
                GameObject obj = Instantiate(mmashPrefab) as GameObject;
                int appera_x = Random.Range(BOUND_LEFT, BOUNT_RIGHT);//x좌표 범위 지정
                obj.transform.position = new Vector3(appera_x, 7, 0);
                ///isFinish = false;
            }




    }

}
