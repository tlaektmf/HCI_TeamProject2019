using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite sp = null;
    float speed;
    void Start()
    {
        SpriteRenderer sr = gameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        int r = Random.Range(1, 3);
        sp = Resources.Load<Sprite>("game2/background/cloud" + r);
        sr.sprite = sp;
        sr.sortingOrder = 3;

        float x = Random.Range(-6.0f, 6.0f);
        float y = Random.Range(2.0f, 6.5f);
        transform.position = new Vector3(x, y, 0);

        speed = Random.Range(0.3f, 1.0f);
        float scale = 0.25f / speed;
        if (scale > 0.45f) scale = 0.45f;
        transform.localScale = new Vector3(scale, scale,1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0,0);

        if(transform.position.x < -6.0f)
        {
            transform.Translate(12.0f, 0, 0);
        }
    }
}
