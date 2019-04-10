using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(demoThread());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator demoThread()
    {
        yield return StartCoroutine(checkFile());
    }
    
    //public IEnumerator checkFile()
    //{

    //}
}
