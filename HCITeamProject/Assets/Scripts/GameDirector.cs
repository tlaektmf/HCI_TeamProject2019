using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    int PLAYER_SIZE_CONTROL_TIME = 5;
    GameObject mplayer;
    bool end_eatMashroom = false;
    // Start is called before the first frame update
    void Start()
    {
        this.mplayer = GameObject.Find("player_man");
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
        Debug.Log("crush bomb game over");
    }

    /*
     * 미니게임 3에서 사용되는 함수
     */
    public void miniGame3Clear()
    {
        //evil과 충돌하는 경우 clear
        Debug.Log("mini game 3 clear");
    }

    public void eatMashroom()
    {
        //mushroom과 충돌하는 경우
        Debug.Log("eat mashroom");

        StartCoroutine(changeSize());
        
    }
    public IEnumerator changeSize()
    {
        this.mplayer.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(PLAYER_SIZE_CONTROL_TIME);//WaitForSeconds객체를 생성해서 반환
        this.mplayer.transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }
}
