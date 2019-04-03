using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     사용자 정의 함수
     */
     public void GameOver()
    {
        //폭탄과 충돌하는 경우 game over
        
    }

    /*
     * 미니게임 3에서 사용되는 함수
     */
    public void miniGame3Clear()
    {
        //evil과 충돌하는 경우 clear
        Debug.Log("mini game 3 clear");
    }

}
