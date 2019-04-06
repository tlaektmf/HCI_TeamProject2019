using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgscrolling : MonoBehaviour
{
    public float speed = 1.0f;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        GameObject controller = GameObject.Find("Game2Controller");
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * speed * Game2Controller.speed, 7.2f);
        if(Game2Controller.speed > 0)
        {
            transform.position = startPos - Vector3.right * newPos;
        }
    }
}
