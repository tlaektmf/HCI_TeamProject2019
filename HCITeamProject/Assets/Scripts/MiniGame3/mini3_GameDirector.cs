using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mini3_GameDirector : MonoBehaviour
{
    int CLEAR_CONTROL_TIME = 30;//default

    // Start is called before the first frame update
    void Start()
    {


        /*
        * 난이도 지정////////////////////////////////////////////////
        */
        //총 게임 시간 조절(난이도가 높아질수록 짧아짐)
        if (SceneController.difficulty == "easy")
        {
            CLEAR_CONTROL_TIME = 40;
        }
        else if (SceneController.difficulty == "normal")
        {
            CLEAR_CONTROL_TIME = 30;
        }
        else if (SceneController.difficulty == "hard")
        {
            CLEAR_CONTROL_TIME = 20;
        }
        ///////////////////////////////////////////////////////////////
        
        StartCoroutine(miniGame3End());
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    사용자 정의 함수 - 미니게임 3
    */

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
        GameOver();//특정 시간초가 지나면 game over
    }

    /*
     * 사용자 정의 함수- 미니게임 1, 미니게임 3 공통
     */
    public void GameOver()
    {
        //폭탄과 충돌하는 경우 game over
        //minigame3에서 특정 시간 초가 흐르는 경우
        Debug.Log("game over , show bad ending");
        SceneController.state = "end";
        SceneManager.LoadScene("EmptyScene");

    }

}
