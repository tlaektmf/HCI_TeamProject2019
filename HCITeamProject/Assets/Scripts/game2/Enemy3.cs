using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    // Start is called before the first frame update
    Vector3 move;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        move = new Vector3(-1, 0, 0);
        transform.localScale = new Vector3(1.0f, 0.15f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + move * Game2Controller.speed * Time.deltaTime;
        if(transform.position.x < 3 - Random.Range(0, 1.5f) && transform.localScale.y < 1)
        {
            transform.localScale += new Vector3(0f, Time.deltaTime * 10, 0f);
        }
    }

    public override void Die()
    {
        rigid.velocity = new Vector2(17f, 10.0f);
        GetComponent<BoxCollider2D>().enabled = false;
        rigid.AddTorque(450f);
    }
}
