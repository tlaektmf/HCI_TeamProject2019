using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    // Start is called before the first frame update
    float arot;
    float aspeed = 0;
    float speed = 1;
    float rot = 0;
    void Start()
    {
        rot = Random.Range(0, 6.28f);
        arot = Random.Range(-1, 1);
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rot += arot * Time.deltaTime;

        float dx = Mathf.Cos(rot);
        float dy = Mathf.Sin(rot);

        transform.Translate(Vector3.right * Time.deltaTime * speed);
        transform.localEulerAngles = (Vector3.forward * (rot / 3.14f * 180f));

        arot += Time.deltaTime * (Random.Range(0, 8f) - 4f);
        aspeed += Time.deltaTime * (Random.Range(0f, 1f) - 0.5f);
        speed += aspeed * Time.deltaTime;
        if (speed < 0.5f)
        {
            speed = 0.5f;
            aspeed = 0;
        }
        if(speed > 3f)
        {
            speed = 3f;
            aspeed = 0;
        }

        Vector3 pos = transform.position;
        if (pos.x < -4f) pos.x = 4f;
        if (pos.x > 4f) pos.x = -4f;
        if (pos.y < -7f) pos.y = 7f;
        if (pos.y > 7f) pos.y = -7f;
        transform.position = pos;
    }
}
