using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapViewAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(720, 1280, true);
        Camera.main.orthographicSize = 1280 / (100.0f * 2.0f); // 카메라 수직길이 절반 / 100
    }
    void Start()
    {
        SoundManager.Instance.PlayMusicWithPath("audio/common/mapview");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
