using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2Controller : MonoBehaviour
{
    public static float speed = 5.0f;
    public static int state = 0; // 0: normal, 1:dead, 2: clear
    public static int stage = 0;
    public static int phase = 0;

    static float deadTime;
    static float portalTime;

    public static void Setting(int stage, int phase)
    {
        Game2Controller.stage = stage;
        Game2Controller.phase = phase;
        GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>().SetStage(stage, phase);
        speed = 4f + 2f * stage;
        state = 0;
        deadTime = 0;
        portalTime = 0;
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
        int phase = SceneController.phase;
        SceneController.phase = 0;

        int difficulty = 0;
        if (diff == "easy") difficulty = 0;
        if (diff == "normal") difficulty = 1;
        if (diff == "hard") difficulty = 2;
        Setting(difficulty, phase);
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
                deadTime = 0;
            }
            
        }
        else if (state == 4)
        {
            portalTime += Time.deltaTime;
            if (portalTime > 1.0f)
            {
                portalTime = 0;
                if (phase == 2)
                {
                    SceneController.state = "clear";
                    SceneManager.LoadScene("EmptyScene");
                    SoundManager.Instance.Stop();
                }
                else
                {
                    SceneController.phase = Game2Controller.phase + 1;
                    SceneManager.LoadScene("Minigame2");
                }
            }
        }
    }
}
