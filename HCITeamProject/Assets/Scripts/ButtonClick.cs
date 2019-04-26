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

    public void stage1(int difficulty)
    {
        SceneController.stage = "1";
        string temp = "";
        if (difficulty == 0) temp = "easy";
        if (difficulty == 1) temp = "normal";
        if (difficulty == 2) temp = "hard";
        SceneController.difficulty = temp;
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);
        SceneManager.LoadScene("EmptyScene");
    }

    public void stage3(int difficulty)
    {
        SceneController.stage = "3";
        string temp = "";
        if (difficulty == 0) temp = "easy";
        if (difficulty == 1) temp = "normal";
        if (difficulty == 2) temp = "hard";
        SceneController.difficulty = temp;
        SceneController.state = null;
        Debug.Log(SceneController.stage + " " + SceneController.difficulty);
        SceneManager.LoadScene("EmptyScene");
    }

    public void stage2(int difficulty)
    {
        SceneController.stage = "2";
        string temp = "easy";
        if (difficulty == 0) temp = "easy";
        if (difficulty == 1) temp = "normal";
        if (difficulty == 2) temp = "hard";
        SceneController.difficulty = temp;
        SceneController.state = null;
        SceneManager.LoadScene("EmptyScene");
    }
}
