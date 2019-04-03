using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Controller : MonoBehaviour
{
    public static float speed = 3.0f;
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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
