using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mini3_GameDirector : MonoBehaviour
{
    int CLEAR_CONTROL_TIME = 30;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(miniGame3End());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    사용자 정의 함수 - 미니게임 3
    */

    //public IEnumerator miniGame3Clear()
    //{
    //    //성과 충돌하는 경우 clear
    //    Debug.Log("mini game 3 clear");
    //    yield return new WaitForSeconds(CASTLE_SHOW_CONTROL_TIME);//WaitForSeconds객체를 생성해서 반환
    //    SceneManager.LoadScene("ClearMiniGame3");

    //}

    public void miniGame3Clear()
    {
        //성과 충돌하는 경우 clear
        Debug.Log("mini game 3 clear");
        SceneController.state = "clear";
        SceneManager.LoadScene("EmptyScene");

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
        SceneController.state = "end";
        SceneManager.LoadScene("EmptyScene");

    }

}
