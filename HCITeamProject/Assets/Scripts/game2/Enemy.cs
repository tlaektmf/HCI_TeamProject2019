using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 move;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        move = new Vector3(-1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + move * Game2Controller.speed * Time.deltaTime;
    }

    public void Die()
    {
        rigid.velocity = new Vector2(17f, 10.0f);
        GetComponent<BoxCollider2D>().enabled = false;
        rigid.AddTorque(450f);
    }
}
