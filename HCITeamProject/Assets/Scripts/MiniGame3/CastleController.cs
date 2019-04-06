using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    GameObject mplayer;//케릭터 오브젝트
    GameObject director;

    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.Find("mini3_GameDirector");
        this.mplayer = GameObject.Find("player_man_back");//케릭터오브젝트
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
