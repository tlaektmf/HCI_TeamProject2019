using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public GameObject mbombPrefab;//폭탄 프리팹을 넣을 변수(아울렛)
    float span=1.0f;//1초마다 1개씩 폭탄을 생성
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;//Time.deltaTime : 앞프레임과 현재 프레임의 시간차이
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject obj = Instantiate(mbombPrefab) as GameObject;
            int appera_x = Random.Range(-6, 7);//-6 ~ 7 범위로 지정
            obj.transform.position = new Vector3(appera_x, 7, 0);
        }
        
    }
}
