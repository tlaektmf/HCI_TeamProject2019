using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    // Start is called before the first frame update
    Vector3 move;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        float r = 5f + Game2Controller.stage * 3f;
        rigid.velocity = new Vector2(-r, 0);
        move = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + move * Game2Controller.speed * Time.deltaTime;
    }

    public override void Die()
    {
        rigid.velocity = new Vector2(30f, -2.0f);
        GetComponent<BoxCollider2D>().enabled = false;
        rigid.AddTorque(1500f);
    }
}
