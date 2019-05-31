using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public GameObject map4;

    GameObject[] maps;

    void Start()
    {
        maps = new GameObject[4];
        maps[0] = map1;
        maps[1] = map2;
        maps[2] = map3;
        for (int i = 0; i < 3; i++)
            maps[i].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int phase = Game2Controller.phase;
        float x = Game2Controller.speed / Game2Controller.total_distance;
        maps[phase].SetActive(true);
        maps[phase].transform.position += new Vector3(x * Time.deltaTime, 0, 0);
    }
}
