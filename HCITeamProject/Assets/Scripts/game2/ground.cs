using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    GameObject other;
    GameObject prev = null;
    static int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (name == "ground1")
        {
            other = GameObject.Find("ground2");
        }
        else
        {
            other = GameObject.Find("ground1");
            prev = other;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -8)
        {
            transform.position = new Vector3(other.transform.position.x + 8f, transform.position.y, transform.position.z);
            if(++cnt % 4 == 0)
            {
                transform.Translate(2.0f,0,0);
            }
            else transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        transform.Translate(-Time.deltaTime * Game2Controller.speed, 0, 0);
    }
}
