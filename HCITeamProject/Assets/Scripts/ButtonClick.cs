using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    bool map = false;
    string str = "";
    GameObject stage1_easy_btn;
    GameObject stage3_easy_btn;

    // Start is called before the first frame update
    void Start()
    {

        if (!map&&PlayerPrefs.GetString("boss") == "clear")
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
        
        string[] str2 = str.Split(new char[] { '_' });
        string stage_num = str2[0];
        string stage_diffculty = str2[1];
        /*MapView에서 이루어져야 되는데, SceneController는 EmptyScene부터 관리하는 것이 아닌가? 어떻게 접근해야 될까..*/

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
