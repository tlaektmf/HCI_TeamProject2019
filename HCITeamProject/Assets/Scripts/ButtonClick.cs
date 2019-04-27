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

        if (!map && PlayerPrefs.GetString("1") != null)
        {

            if (!map && PlayerPrefs.GetString("boss") == "clear")
            {
                //map = true;
                str = PlayerPrefs.GetString("boss");
                string[] str2 = str.Split(new char[] { '_' });
                boss_img.sprite = Resources.Load<Sprite>("활성화");

            }
            if (!map && PlayerPrefs.GetString("3") == "clear")
            {
                //map = true;
                str = PlayerPrefs.GetString("3");
                string[] str2 = str.Split(new char[] { '_' });
                
                if (str2[1] == "hard")
                {
                    stage3_easy_btn_img.sprite = Resources.Load<Sprite>("활성화");
                    stage3_middle_btn_img.sprite = Resources.Load<Sprite>("활성화");
                    stage3_hard_btn_img.sprite = Resources.Load<Sprite>("활성화");
                }
                else if (str2[1] == "middle")
                {
                    stage3_easy_btn_img.sprite = Resources.Load<Sprite>("활성화");
                    stage3_middle_btn_img.sprite = Resources.Load<Sprite>("활성화");
                }
                else
                {
                    stage3_easy_btn_img.sprite = Resources.Load<Sprite>("활성화");
                }
            }
            if (!map && PlayerPrefs.GetString("2") == "clear")
            {
                //map = true;
                str = PlayerPrefs.GetString("2");
                string[] str2 = str.Split(new char[] { '_' });
                string stage_diffculty = str2[1];
                if (str2[1] == "hard")
                {
                    stage2_easy_btn_img.sprite = Resources.Load<Sprite>("활성화");
                    stage2_middle_btn_img.sprite = Resources.Load<Sprite>("활성화");
                    stage2_hard_btn_img.sprite = Resources.Load<Sprite>("활성화");
                }
                else if (str2[1] == "middle")
                {
                    stage2_easy_btn_img.sprite = Resources.Load<Sprite>("활성화");
                    stage2_middle_btn_img.sprite = Resources.Load<Sprite>("활성화");
                }
                else
                {
                    stage2_easy_btn_img.sprite = Resources.Load<Sprite>("활성화");
                }
            }
            if (!map && PlayerPrefs.GetString("1") == "clear")
            {
                map = true;
                str = PlayerPrefs.GetString("1");
                string[] str2 = str.Split(new char[] { '_' });
                string stage_diffculty = str2[1];
                if (str2[1] == "hard")
                {
                    stage1_easy_btn_img.sprite = Resources.Load<Sprite>("활성화");
                    stage1_middle_btn_img.sprite = Resources.Load<Sprite>("활성화");
                    stage1_hard_btn_img.sprite = Resources.Load<Sprite>("활성화");
                }
                else if (str2[1] == "middle")
                {
                    stage1_easy_btn_img.sprite = Resources.Load<Sprite>("활성화");
                    stage1_middle_btn_img.sprite = Resources.Load<Sprite>("활성화");
                }
                else
                {
                    stage1_easy_btn_img.sprite = Resources.Load<Sprite>("활성화");
                }
            }

            //ImageChange(str);

        }

    }
    void ImageChange(string str)
    {
        string[] str2 = str.Split(new char[] { '_' });
        string stage_diffculty = str2[1];
        int stage_num=Int32.Parse(str2[0]);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //Stage1
    public void stage1_easy()
    {
        SceneController.stage = "1";
        SceneController.difficulty = "easy";
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);

        SceneManager.LoadScene("EmptyScene");
    }

    public void stage1_middle()
    {
        SceneController.stage = "1";
        SceneController.difficulty = "middle";
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);

        SceneManager.LoadScene("EmptyScene");
    }
    public void stage1_hard()
    {
        SceneController.stage = "1";
        SceneController.difficulty = "hard";
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);

        SceneManager.LoadScene("EmptyScene");
    }
    //Stage2
    public void stage2_easy()
    {
        SceneController.stage = "2";
        SceneController.difficulty = "easy";
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);

        SceneManager.LoadScene("EmptyScene");
    }
    public void stage2_middle()
    {
        SceneController.stage = "2";
        SceneController.difficulty = "middle";
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);

        SceneManager.LoadScene("EmptyScene");
    }
    public void stage2_hard()
    {
        SceneController.stage = "2";
        SceneController.difficulty = "hard";
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);

        SceneManager.LoadScene("EmptyScene");
    }
    //Stage3
    public void stage3_easy()
    {
        SceneController.stage = "3";
        SceneController.difficulty = "easy";
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);

        SceneManager.LoadScene("EmptyScene");
    }
    public void stage3_middle()
    {
        SceneController.stage = "3";
        SceneController.difficulty = "middle";
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);

        SceneManager.LoadScene("EmptyScene");
    }
    public void stage3_hard()
    {
        SceneController.stage = "3";
        SceneController.difficulty = "hard";
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);

        SceneManager.LoadScene("EmptyScene");
    }
    public void replay()
    {
        SceneController.state = null;
        SceneManager.LoadScene("EmptyScene");
    }

    //Boss
    public void boss()
    {
        SceneController.stage = "boss";
        SceneController.difficulty = "";
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);

        SceneManager.LoadScene("EmptyScene");
    }
}
