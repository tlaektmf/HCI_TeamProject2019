using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    public static float thrust = 5.5f;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            Rigidbody2D rigid = player.GetComponent<Rigidbody2D>();
            rigid.velocity = new Vector2(0, thrust);
        }
    }
}
