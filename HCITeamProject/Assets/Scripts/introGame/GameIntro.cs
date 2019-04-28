using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameIntro : MonoBehaviour
{
    GameObject image;
    SpriteRenderer spriteRenderer;
    int count = 1;
    bool key = false;
    void Start()
    {
        image = GameObject.FindGameObjectWithTag("story");
        spriteRenderer = image.GetComponent<SpriteRenderer>();
        StartCoroutine("wait");
    }

    // Update is called once per frame
    void Update()
    {
               
    }
    IEnumerator wait()
    {
        spriteRenderer.sprite = (Sprite)Resources.Load("story_1", typeof(Sprite));
        yield return new WaitForSeconds(3f);
        spriteRenderer.sprite = (Sprite)Resources.Load("story_2", typeof(Sprite));
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MapView");
    }
}
