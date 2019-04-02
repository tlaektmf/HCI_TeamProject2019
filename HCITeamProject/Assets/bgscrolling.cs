using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgscrolling : MonoBehaviour
{
    public float speed = 2.0f;
    public int seq = 0;
    float itemSizeX;
    GameObject other;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        itemSizeX = sr.bounds.size.x;
        
        if(name == "back21")
        {
            other = GameObject.Find("back22");
        }
        else
        {
            other = GameObject.Find("back21");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if(transform.position.x < -itemSizeX)
        {
            transform.position = new Vector3(other.transform.position.x + itemSizeX, transform.position.y, 0);
        }
    }
}
