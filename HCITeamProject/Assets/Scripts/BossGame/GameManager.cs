using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour {

    AudioSource music;      // 배경 및 게임오버 음악
    Transform spPoint;      // SpawnPoint
    Vector3 wrdSize;        // 화면의 크기 (월드좌표)
    public GameObject branchPrefab;
    public GameObject birdPrefab;
    public GameObject princess;
    public GameObject chkpoint;
    public GameObject mainCamera;   //카메라 이동
    //public GameObject Owl;   //주인공
    public Text timeText;
    bool rest = false;
    bool pcoll = false; //princess Collision
    private float time=1;

    bool gameclear = false;
    

    private const float inchTocm = 2.54f;
    [SerializeField]
    private EventSystem eventSystem = null;
    [SerializeField]
    private float dragThresholdCM = 0.5f;

    private void SetDragThreshold()
    {
        if (eventSystem != null)
        {
            eventSystem.pixelDragThreshold = (int)(dragThresholdCM * Screen.dpi / inchTocm);
        }
    }
    void Awake () {
        Screen.SetResolution(720, 1280, true);
        SetDragThreshold();
        InitGame();
    }

    void Start()
    {
        SoundManager.Instance.Stop();
        SoundManager.Instance.PlayMusicWithPath("audio/boss/boss");
    }

    // Update is called once per frame
    void Update () {
        
        //MakeGift();
        if (time > 0) { 
            time -= Time.deltaTime;
            timeText.text = "남은시간 : " + Mathf.Ceil(time).ToString();
            MakeBranch();
            MakeBird();
            cameraUp();
        }
        else
        {
            //Clear!!
            if (!gameclear)
            {
                Vector3 pos = spPoint.position;
                princess.transform.position = pos;

                // 나뭇가지
                GameObject branch = Instantiate(branchPrefab) as GameObject;
                Vector3 b_pos = new Vector3(pos.x, pos.y-(float)0.8, pos.z);
                branch.transform.position = b_pos;
                gameclear = true;
            }
            if (rest && pcoll)
            {
                //Owl.transform.position = princess.transform.position;
                SoundManager.Instance.Stop();
                SoundManager.Instance.PlayEffectWithPath("audio/common/win");
                SceneController.state = "clear";
                //SceneController.stage = "boss";
                SceneManager.LoadScene("EmptyScene");    //GameClear 종류 두개로 바뀜. 확인해서 조건문도 바꿀것
            }
           
        }

    }
    
    // 나뭇가지 만들기
    void MakeBranch () {
        // 나뭇가지의 개수 구하기
        int cnt = GameObject.FindGameObjectsWithTag("Branch").Length;
        if (cnt > 3) return;

        // SpawnPoint 높이에 지그재그로 배치
        Vector3 pos = spPoint.position;
        pos.x = Random.Range(-wrdSize.x * 0.5f, wrdSize.x * 0.5f);

        // 나뭇가지
        GameObject branch = Instantiate(branchPrefab) as GameObject;
        branch.transform.position = pos;

        // SpawnPoint를 위로 이동
        spPoint.position += new Vector3(0, (float)2.5, 0);
    }

    // 참새 만들기
    void MakeBird() {
        // 참새 수 구하기
        int cnt = GameObject.FindGameObjectsWithTag("Bird").Length;
        if (cnt > 7 || Random.Range(0, 1000) < 980) return;

        Vector3 pos = spPoint.position;
        pos.y -= Random.Range(0, 1f);

        GameObject bird = Instantiate(birdPrefab) as GameObject;
        bird.transform.localScale = birdPrefab.transform.localScale;
        bird.transform.position = pos;
        
    }

    // 선물상자 만들기
    void MakeGift () {
        // 선물상자 수 구하기
        int cnt = GameObject.FindGameObjectsWithTag("Gift").Length;
        if (cnt > 5 || Random.Range(0, 1000) < 980) return;

        // 위치
        Vector3 pos = spPoint.position;
        pos.x = Random.Range(-wrdSize.x * 0.5f, wrdSize.x * 0.5f);
        pos.y += Random.Range(0.5f, 1.5f);

        // 이름
        GameObject gift = Instantiate(Resources.Load("Gift0")) as GameObject;
        gift.name = "Gift" + Random.Range(0, 3);      // 0~2
        gift.transform.position = pos;
    }

    // 게임 초기화
    void InitGame () {
        // 배경음악
        music = GetComponent<AudioSource>();
        //music.loop = true;

        //if (music.clip != null) {
        //    music.Play();
        //}

        // SpawnPoint
        spPoint = GameObject.Find("SpawnPoint").transform;

        GameObject branch = Instantiate(branchPrefab) as GameObject;
        branch.transform.position = chkpoint.transform.position;

        // World의 크기
        Vector3 scrSize = new Vector3(Screen.width, Screen.height);
        scrSize.z = 10;
        wrdSize = Camera.main.ScreenToWorldPoint(scrSize);

        Cursor.visible = false;
    }
    void BirdStrike()
    {
        //이 함수 다시 타이머 함수로 만들기
        
        //float currentTime=Time.deltaTime+2f;
        //Vector3 owlpos=Owl.transform.position;
        //owlpos.y = owlpos.y;
        //StartCoroutine("wait");
    }

    void SetScore()
    {

    }
    IEnumerator wait2()
    {
        print("로딩즁");
        //Owl.transform.position = princess.transform.position;
        rest = false;
        yield return new WaitForSeconds(1f);
        rest = true;
        print("로딩끝!");
    }
    void GameClear()
    {
        print("용사여 당신은 공주를 구해냈어요!");
        Owl.t = false;
        StartCoroutine("wait2");
        timeText.text = "GameClear!!";
        pcoll = true;
        //SoundManager.Instance.Stop();
        //SoundManager.Instance.PlayEffectWithPath("audio/common/win");
        //SceneController.state = "clear";
        ////SceneController.stage = "boss";
        //SceneManager.LoadScene("EmptyScene");    //GameClear 종류 두개로 바뀜. 확인해서 조건문도 바꿀것
    }
    void GameOver()
    {
        print("당신은 실패했습니다.");
        timeText.text = "GameOver!!";
        SoundManager.Instance.Stop();
        SoundManager.Instance.PlayEffectWithPath("audio/common/gameover_tetris");
        SceneController.state = "end";
        //SceneController.stage = "boss";
        SceneManager.LoadScene("EmptyScene");    //GameOver -> BadEnding
    }
    void cameraUp()
    {
        Vector3 pos = mainCamera.transform.position;
        pos = Vector3.Lerp(pos, new Vector3(pos.x, pos.y+0.6f, pos.z), Time.deltaTime);
        //pos.y += 0.6f*Time.deltaTime;
            //Mathf.Lerp(0.01f * Time.deltaTime); 
        mainCamera.transform.position = pos;
    }
}
