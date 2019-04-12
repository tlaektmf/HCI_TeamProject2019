using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 move;

    void Start()
    {
        move = new Vector3(-1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + move * Game2Controller.speed * Time.deltaTime;
    }
}
