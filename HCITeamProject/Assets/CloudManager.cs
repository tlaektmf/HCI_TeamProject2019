using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject cloudPrefab = Resources.Load("game2/cloud") as GameObject;
        for (int i=0; i<7; i++)
        {
            GameObject cloud = MonoBehaviour.Instantiate(cloudPrefab) as GameObject;
            cloud.name = "cloud" + (i+1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
