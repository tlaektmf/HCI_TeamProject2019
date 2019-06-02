using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mini1_GameDirector : MonoBehaviour
{
    int CLEAR_CONTROL_TIME = 40;
    float time = 40;
    public Text timeText;
    int PLAYER_SIZE_CONTROL_TIME = 5;

    GameObject mplayer;

    // Start is called before the first frame update
    void Start()
    {
        
        this.mplayer = GameObject.Find("player_man");
        /// this.mevil = GameObject.Find("evil");
        StartCoroutine(miniGame1Clear());
        time -= Time.deltaTime;
        timeText.text = "남은시간 : " + Mathf.Ceil(time).ToString();

        SoundManager.Instance.Stop();
        SoundManager.Instance.PlayMusicWithPath("audio/game1/game1");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "남은시간 : " + Mathf.Ceil(time).ToString();
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
        SoundManager.Instance.Stop();
        SoundManager.Instance.PlayEffectWithPath("audio/common/win");
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
