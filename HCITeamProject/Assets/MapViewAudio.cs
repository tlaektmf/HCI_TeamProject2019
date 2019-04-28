using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapViewAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusicWithPath("audio/common/mapview");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
