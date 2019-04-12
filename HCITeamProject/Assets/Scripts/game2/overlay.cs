using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Sprite sp = Resources.Load<Sprite>("game2/background/sky" + (Game2Controller.stage + 1));
        sr.sprite = sp;
        Color tmp = sr.color;
        tmp.a = 0.3f;
        sr.color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
