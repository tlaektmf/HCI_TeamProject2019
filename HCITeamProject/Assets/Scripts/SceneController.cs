using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * [stage]
 * 
 * 1
 * 2
 * 3
 * boss
 * 
 * [difficulty]
 * 
 * hard
 * normal
 * easy
 * 
 * [state]
 * null
 * clear
 * end
 * 
 */

/*
 * 1. 맵뷰에서 스테이지 이동, 클릭 시 
 * stage, difficulty, state=null 가 EmptyScene로 전달됨
 * 
 * 2. 미니게임 성공, 실패 시
 * stage 설정만 해주면 됨
 * 
 * 3. 스토리 카툰 리소스 파일명 통일
 *  예) stage1_easy_story 
 *  
 *  4. 각 미니게임에서는 1에서 받은 difficulty 를 기준으로 난이도를 나눈다.
 */

public class SceneController : MonoBehaviour
{
    public static bool isContinue = false;//재도전 :true
    public static string stage;
    public static string state;
    public static string difficulty;

    GameObject loadImage;
    int WAIT_TIME = 5;

     GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        this.loadImage = GameObject.Find("sceneImage");
        btn = GameObject.Find("replay");
        btn.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("stage :" + stage + "    state : " + state+"   difficulty: "+difficulty);

        if (state == null)
        {
            //게임 전 -> 해당 stage에 맞는 스토리 카툰을 보여줌
            //para : string stage, string difficulty
            showStory();
           
            //(일정 시간 후) 미니게임 스테이지로 이동
            //para : string stage, string difficulty
            StartCoroutine(showStage());
        }
        else
        {
            //게임 후-> 게임 결과에 맞는 엔딩을 보여줌(해피, 배드, 클리어화면)
            
            showEnding();
            //게임 후-> 엔딩/클리어 -> (일정 시간 후) 맵view
            if (state != "end")
            {
                StartCoroutine(showMapView());
            }
           
        }


    }

    void showEnding()
    {
        if (state == "clear" && stage == "boss"&& isContinue==false)
        {
            this.loadImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("hiddenEnding");
        }
        else if (state == "clear" && stage == "boss" && isContinue == true)
        {
            this.loadImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("happyEnding");
        }
        else if (state == "end")
        {
            this.loadImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("badEnding");

            //게임오버 후에는 다시하기 버튼이 나옴
            isContinue = true;
            btn.SetActive(true);
            
        }
        else if (state == "clear")
        {
            this.loadImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("clear");
        }

       
    }

    //para : string stage, string difficulty
    void showStory()
    {
        //resource file name 예시 : stage1_easy_story
        this.loadImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("stage"+stage+"_"+difficulty+"_"+"story");
    }

    public IEnumerator showMapView()
    {
        yield return new WaitForSeconds(WAIT_TIME);//WaitForSeconds객체를 생성해서 반환
        state = null;
        SceneManager.LoadScene("MapView");
    }

    //para : string stage
    public IEnumerator showStage()
    {
        yield return new WaitForSeconds(WAIT_TIME);//WaitForSeconds객체를 생성해서 반환
        if (stage == "boss")
        {
            SceneManager.LoadScene("BossGame");
        }
        else
        {
            SceneManager.LoadScene("miniGame" + stage);
        }
        
    }

}
