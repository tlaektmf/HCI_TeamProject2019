using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    bool map = false;
    string str = "";
    bool null_start = false;
    GameObject stage1_easy_btn;
    Image stage1_easy_btn_img;
    GameObject stage1_middle_btn;
    Image stage1_middle_btn_img;
    GameObject stage1_hard_btn;
    Image stage1_hard_btn_img;

    GameObject stage3_easy_btn;

    // Start is called before the first frame update
    void Start()
    {
        stage1_easy_btn_img = stage1_easy_btn.GetComponent<Image>();
        stage1_middle_btn_img = stage1_middle_btn.GetComponent<Image>();
        stage1_hard_btn_img = stage1_hard_btn.GetComponent<Image>();

        if (!map && PlayerPrefs.GetString("1") != null)
        {

            if (!map && PlayerPrefs.GetString("boss") == "clear")
            {
                map = true;
                str = PlayerPrefs.GetString("boss");
            }
            if (!map && PlayerPrefs.GetString("4") == "clear")
            {
                map = true;
                str = PlayerPrefs.GetString("4");

            }
            if (!map && PlayerPrefs.GetString("3") == "clear")
            {
                map = true;
                str = PlayerPrefs.GetString("3");
            }
            if (!map && PlayerPrefs.GetString("2") == "clear")
            {
                map = true;
                str = PlayerPrefs.GetString("2");
            }
            if (!map && PlayerPrefs.GetString("1") == "clear")
            {
                map = true;
                str = PlayerPrefs.GetString("1");
            }

            ImageChange(str);

        }

    }
    void ImageChange(string str)
    {
        string[] str2 = str.Split(new char[] { '_' });
        string stage_num = str2[0];
        string stage_diffculty = str2[1];

        
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
