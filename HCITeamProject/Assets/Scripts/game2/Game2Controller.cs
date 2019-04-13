using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2Controller : MonoBehaviour
{
    public static float speed = 5.0f;
    public static int state = 0; // 0: normal, 1:dead, 2: clear
    public static int stage = 0;

    static float deadTime;

    public static void Setting(int stage)
    {
        Game2Controller.stage = stage;
        GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>().SetStage(stage);
        speed = 4f + 2f * stage;
        state = 0;
        deadTime = 0;
    }

    private static Game2Controller instance = null;
    public static Game2Controller GetInstance()
    {
        if (!instance)
        {
            instance = (Game2Controller)GameObject.FindObjectOfType(typeof(Game2Controller));
            if (!instance)
                Debug.LogError("Game2Controller has No instance");
        }
        return instance;
    }


    void Awake()
    {
        Screen.SetResolution(720, 1280, true);
        Camera.main.orthographicSize = 1280 / (100.0f * 2.0f); // 카메라 수직길이 절반 / 100

        string diff = SceneController.difficulty;
        int difficulty = 2;
        if (diff == "easy") difficulty = 0;
        if (diff == "normal") difficulty = 1;
        if (diff == "hard") difficulty = 2;
        Setting(difficulty);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 1)
        {
            deadTime += Time.deltaTime;
            if(deadTime > 2.0f)
            {
                SceneController.state = "end";
                SceneManager.LoadScene("EmptyScene");
            }
        }
    }
}
