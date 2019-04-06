using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject cloudPrefab = Resources.Load("game2/background/cloud") as GameObject;
        GameObject cm = GameObject.Find("CloudManager");
        for (int i=0; i<7; i++)
        {
            GameObject cloud = MonoBehaviour.Instantiate(cloudPrefab) as GameObject;
            cloud.name = "cloud" + (i+1);
            cloud.transform.parent = cm.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
