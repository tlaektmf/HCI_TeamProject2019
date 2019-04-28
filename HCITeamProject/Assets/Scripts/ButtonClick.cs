using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ButtonClick : MonoBehaviour
{
    bool map = false;
    string str = "";
    bool null_start = false;
    //stage1
    GameObject stage1_easy_btn;
    Image stage1_easy_btn_img;
    GameObject stage1_middle_btn;
    Image stage1_middle_btn_img;
    GameObject stage1_hard_btn;
    Image stage1_hard_btn_img;

    //stage2
    GameObject stage2_easy_btn;
    Image stage2_easy_btn_img;
    GameObject stage2_middle_btn;
    Image stage2_middle_btn_img;
    GameObject stage2_hard_btn;
    Image stage2_hard_btn_img;

    //stage3
    GameObject stage3_easy_btn;
    Image stage3_easy_btn_img;
    GameObject stage3_middle_btn;
    Image stage3_middle_btn_img;
    GameObject stage3_hard_btn;
    Image stage3_hard_btn_img;

    //boss
    GameObject boss_btn;
    Image boss_img;


    // Start is called before the first frame update
    void Start()
    {
        ///PlayerPrefs.DeleteAll();
        stage1_easy_btn = GameObject.FindGameObjectWithTag("stage1_easy");
        stage2_easy_btn = GameObject.FindGameObjectWithTag("stage2_easy");
        stage3_easy_btn = GameObject.FindGameObjectWithTag("stage3_easy");

        stage1_middle_btn = GameObject.FindGameObjectWithTag("stage1_middle");
        stage2_middle_btn = GameObject.FindGameObjectWithTag("stage2_middle");
        stage3_middle_btn = GameObject.FindGameObjectWithTag("stage3_middle");

        stage1_hard_btn = GameObject.FindGameObjectWithTag("stage1_hard");
        stage2_hard_btn = GameObject.FindGameObjectWithTag("stage2_hard");
        stage3_hard_btn = GameObject.FindGameObjectWithTag("stage3_hard");

        boss_btn = GameObject.FindGameObjectWithTag("boss");

        if (PlayerPrefs.GetString("1_easy") != null){
            print("값이 들어 있어");
        }
        else
        {
            print("값이 안들어 있어");
        }
        if (stage1_easy_btn!=null)
        {
            stage1_easy_btn_img = stage1_easy_btn.GetComponent<Image>();
            stage1_middle_btn_img = stage1_middle_btn.GetComponent<Image>();
            stage1_hard_btn_img = stage1_hard_btn.GetComponent<Image>();

            stage2_easy_btn_img = stage2_easy_btn.GetComponent<Image>();
            stage2_middle_btn_img = stage2_middle_btn.GetComponent<Image>();
            stage2_hard_btn_img = stage2_hard_btn.GetComponent<Image>();

            stage3_easy_btn_img = stage3_easy_btn.GetComponent<Image>();
            stage3_middle_btn_img = stage3_middle_btn.GetComponent<Image>();
            stage3_hard_btn_img = stage3_hard_btn.GetComponent<Image>();

            boss_img = boss_btn.GetComponent<Image>();
            
            if (PlayerPrefs.GetString("1_easy") != null)
            {
                Debug.Log("1_easy_state "+PlayerPrefs.GetString("1_easy"));
                if (PlayerPrefs.GetString("boss_") == "clear")
                {
                    boss_img.sprite = Resources.Load<Sprite>("activate");
                }
                if (PlayerPrefs.GetString("3_hard") == "clear")
                {
                    stage3_hard_btn_img.sprite = Resources.Load<Sprite>("activate");
                    stage3_easy_btn_img.sprite = Resources.Load<Sprite>("activate");
                    stage3_middle_btn_img.sprite = Resources.Load<Sprite>("activate");
                }
                else if (PlayerPrefs.GetString("3_middle") == "clear")
                {
                    stage3_easy_btn_img.sprite = Resources.Load<Sprite>("activate");
                    stage3_middle_btn_img.sprite = Resources.Load<Sprite>("activate");
                }
                else
                {
                    stage3_easy_btn_img.sprite = Resources.Load<Sprite>("activate");
                }

                if (PlayerPrefs.GetString("2_hard") == "clear")
                {
                    stage2_easy_btn_img.sprite = Resources.Load<Sprite>("activate");
                    stage2_middle_btn_img.sprite = Resources.Load<Sprite>("activate");
                    stage2_hard_btn_img.sprite = Resources.Load<Sprite>("activate");
                }
                else if (PlayerPrefs.GetString("2_middle") == "clear")
                {
                    stage2_middle_btn_img.sprite = Resources.Load<Sprite>("activate");
                    stage2_easy_btn_img.sprite = Resources.Load<Sprite>("activate");
                }
                else
                {
                    stage2_easy_btn_img.sprite = Resources.Load<Sprite>("activate");
                }

                if (PlayerPrefs.GetString("1_hard") == "clear")
                {
                    stage1_easy_btn_img.sprite = Resources.Load<Sprite>("activate");
                    stage1_middle_btn_img.sprite = Resources.Load<Sprite>("activate");
                    stage1_easy_btn_img.sprite = Resources.Load<Sprite>("activate");
                }
                else if (PlayerPrefs.GetString("1_middle") == "clear")
                {
                    stage1_easy_btn_img.sprite = Resources.Load<Sprite>("activate");
                    stage1_middle_btn_img.sprite = Resources.Load<Sprite>("activate");
                }
                else
                {
                    stage1_easy_btn_img.sprite = Resources.Load<Sprite>("activate");
                }

            }
        }
        

        }

    void commonAction()
    {
        SceneController.state = null;
        SceneManager.LoadScene("EmptyScene");
        SoundManager.Instance.Stop();
        SoundManager.Instance.PlayEffectWithPath("audio/common/change");
    }

    //Stage1
    public void stage1_easy()
    {
        SceneController.stage = "1";
        SceneController.difficulty = "easy";
        commonAction();
    }

    public void stage1_middle()
    {
        SceneController.stage = "1";
        SceneController.difficulty = "middle";
        commonAction();

    }
    public void stage1_hard()
    {
        SceneController.stage = "1";
        SceneController.difficulty = "hard";
        commonAction();
    }
    //Stage2
    public void stage2_easy()
    {
        SceneController.stage = "2";
        SceneController.difficulty = "easy";
        commonAction();
    }
    public void stage2_middle()
    {
        SceneController.stage = "2";
        SceneController.difficulty = "middle";
        commonAction();
    }
    public void stage2_hard()
    {
        SceneController.stage = "2";
        SceneController.difficulty = "hard";
        commonAction();
    }
    //Stage3
    public void stage3_easy()
    {
        SceneController.stage = "3";
        SceneController.difficulty = "easy";
        commonAction();
    }
    public void stage3_middle()
    {
        SceneController.stage = "3";
        SceneController.difficulty = "middle";
        commonAction();
    }
    public void stage3_hard()
    {
        SceneController.stage = "3";
        SceneController.difficulty = "hard";
        commonAction();
    }
    public void replay()
    {
        commonAction();
    }

    //Boss
    public void boss()
    {
        SceneController.stage = "boss";
        SceneController.difficulty = "";
        commonAction();
    }
}
