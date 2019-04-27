using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
