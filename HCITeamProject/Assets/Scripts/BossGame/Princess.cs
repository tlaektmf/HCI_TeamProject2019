﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //공주랑 충돌한다.
    void PrincessCollision()
    {
        // GameManager에 통지
        FindObjectOfType<GameManager>().SendMessage("GameClear");

    }
}
