using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Obstacle
{
    public float time;
    public int type;
    public Obstacle(float time, int type)
    {
        this.time = time;
        this.type = type;
    }
}

public class ObstacleManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject enemyPrefab = null;
    GameObject om = null;
    public Obstacle nextObstacle = null;
    public List<Obstacle> obstacleList = new List<Obstacle>();

    int cnt = 0;
    public void genEnemy(int type)
    {
        Debug.Log(enemyPrefab);
        if(enemyPrefab)
        {
            GameObject enemy = MonoBehaviour.Instantiate(enemyPrefab) as GameObject;
            enemy.transform.parent = om.transform;
            enemy.name = "obs" + cnt++;
        }
    }

    void Start()
    {
        om = GameObject.Find("ObstacleManager");
        enemyPrefab = Resources.Load("game2/object/Enemy") as GameObject;

        obstacleList.Add(new Obstacle(5.0f, 1));
        obstacleList.Add(new Obstacle(8.0f, 1));
        obstacleList.Add(new Obstacle(11.0f, 1));
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleList.Count > 0)
        {
            nextObstacle = obstacleList[0];
            if(nextObstacle.time <= Time.time)
            {
                genEnemy(nextObstacle.type);
                obstacleList.Remove(nextObstacle);
                if (obstacleList.Count == 0) nextObstacle = null;
                else nextObstacle = obstacleList[0];
            }
        }
    }
}
