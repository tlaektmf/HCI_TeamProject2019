using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game2sky : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Sprite sp = Resources.Load<Sprite>("game2/background/sky" + (Game2Controller.stage+1));
        sr.sprite = sp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
