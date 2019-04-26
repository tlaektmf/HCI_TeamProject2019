using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mini1_GameDirector : MonoBehaviour
{
    int CLEAR_CONTROL_TIME = 40;

    int PLAYER_SIZE_CONTROL_TIME = 5;

    GameObject mplayer;

    // Start is called before the first frame update
    void Start()
    {
        
        this.mplayer = GameObject.Find("player_man");
        /// this.mevil = GameObject.Find("evil");
        StartCoroutine(miniGame1Clear());

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
        SceneController.state = "clear";
        SceneManager.LoadScene("EmptyScene");
        

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
