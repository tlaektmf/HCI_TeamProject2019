using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    int CLEAR_CONTROL_TIME =40;
    int CASTLE_SHOW_CONTROL_TIME = 3;
    int PLAYER_SIZE_CONTROL_TIME = 5;

    GameObject mplayer;

    // Start is called before the first frame update
    void Start()
    {
        this.mplayer = GameObject.Find("player_man");
       /// this.mevil = GameObject.Find("evil");
        StartCoroutine(miniGame1Clear());
        StartCoroutine(miniGame3End());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     사용자 정의 함수 - 미니게임 1
     */

     
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

    public IEnumerator miniGame1Clear()
    {
        //40초가 지나는 경우 clear
        yield return new WaitForSeconds(CLEAR_CONTROL_TIME);
        Debug.Log("mini game 1 clear");
        SceneManager.LoadScene("ClearMiniGame1");
    }


    /*
     사용자 정의 함수 - 미니게임 3
     */

    public IEnumerator miniGame3Clear()
    {
        //evil과 충돌하는 경우 clear

        //1. 우선 evil을 없애고
        //2. 3초후, 클리어 화면으로 전환한다

        yield return new WaitForSeconds(CASTLE_SHOW_CONTROL_TIME);//WaitForSeconds객체를 생성해서 반환
        SceneManager.LoadScene("ClearMiniGame3");
        Debug.Log("mini game 3 clear");
    }

    public IEnumerator miniGame3End()
    {
        yield return new WaitForSeconds(CLEAR_CONTROL_TIME);//WaitForSeconds객체를 생성해서 반환
        GameOver();//40초가 지나면 game over
    }

    /*
     * 사용자 정의 함수- 미니게임 1, 미니게임 3 공통
     */
    public void GameOver()
    {
        //폭탄과 충돌하는 경우 game over
        //minigame3에서 40초가 흐르는 경우
        Debug.Log("game over , show bad ending");
        SceneManager.LoadScene("BadEnding");
    }


}
