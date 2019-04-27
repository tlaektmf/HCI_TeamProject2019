using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle
{
    public float distance;
    public int type;
    public Obstacle(float distance, int type)
    {
        this.distance = distance;
        this.type = type;
    }
}

public class ObstacleManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject enemyPrefab = null;
    GameObject enemyPrefab2 = null;
    GameObject portalPrefab = null;
    GameObject om = null;
    public static Obstacle nextObstacle = null;
    public List<Obstacle> obstacleList = new List<Obstacle>();

    int cnt = 0;
    float distance = 0f;
    public void genEnemy(int type)
    {
        GameObject enemy = null;
        GameObject portal = null;
        if (enemyPrefab && type == 1)
        {
            enemy = MonoBehaviour.Instantiate(enemyPrefab) as GameObject;
        }
        else if(enemyPrefab2 && type == 2)
        {
            enemy = MonoBehaviour.Instantiate(enemyPrefab2) as GameObject;
        }
        else if (portalPrefab && type == 100)
        {
            portal = MonoBehaviour.Instantiate(portalPrefab) as GameObject;
        }
        if (enemy)
        {
            enemy.transform.parent = om.transform;
            enemy.name = "obs" + cnt++;
            enemy.tag = "enemy";
        }
        if (portal)
        {
            portal.transform.parent = om.transform;
            portal.name = "obs" + cnt++;
            portal.tag = "portal";
        }
    }

    public void SetStage(int stage, int phase)
    {
        switch (stage)
        {
        case 0:
            if(phase == 0)
            {
                obstacleList.Add(new Obstacle(15.0f, 1));
                obstacleList.Add(new Obstacle(24.0f, 1));
                obstacleList.Add(new Obstacle(33.0f, 1));
                obstacleList.Add(new Obstacle(42.0f, 2));
                obstacleList.Add(new Obstacle(46.0f, 1));
                obstacleList.Add(new Obstacle(55.0f, 2));
                obstacleList.Add(new Obstacle(58.0f, 1));
                obstacleList.Add(new Obstacle(75.0f, 100));
            }
            else if (phase == 1)
            {
                obstacleList.Add(new Obstacle(15.0f, 1));
                obstacleList.Add(new Obstacle(24.0f, 1));
                obstacleList.Add(new Obstacle(33.0f, 1));
                obstacleList.Add(new Obstacle(42.0f, 2));
                obstacleList.Add(new Obstacle(46.0f, 1));
                obstacleList.Add(new Obstacle(55.0f, 2));
                obstacleList.Add(new Obstacle(58.0f, 1));
                obstacleList.Add(new Obstacle(75.0f, 100));
            }
            else
            {
                obstacleList.Add(new Obstacle(15.0f, 1));
                obstacleList.Add(new Obstacle(24.0f, 1));
                obstacleList.Add(new Obstacle(33.0f, 1));
                obstacleList.Add(new Obstacle(42.0f, 2));
                obstacleList.Add(new Obstacle(46.0f, 1));
                obstacleList.Add(new Obstacle(55.0f, 2));
                obstacleList.Add(new Obstacle(58.0f, 1));
                obstacleList.Add(new Obstacle(75.0f, 100));
            }
            break;
        case 1:
            obstacleList.Add(new Obstacle(15.0f, 1));
            obstacleList.Add(new Obstacle(24.0f, 1));
            obstacleList.Add(new Obstacle(33.0f, 1));
            obstacleList.Add(new Obstacle(42.0f, 2));
            obstacleList.Add(new Obstacle(46.0f, 1));
            obstacleList.Add(new Obstacle(55.0f, 2));
            obstacleList.Add(new Obstacle(58.0f, 1));
            obstacleList.Add(new Obstacle(80.0f, 100));

                break;
        case 2:
            obstacleList.Add(new Obstacle(15.0f, 1));
            obstacleList.Add(new Obstacle(24.0f, 1));
            obstacleList.Add(new Obstacle(33.0f, 1));
            obstacleList.Add(new Obstacle(42.0f, 2));
            obstacleList.Add(new Obstacle(46.0f, 1));
            obstacleList.Add(new Obstacle(55.0f, 2));
            obstacleList.Add(new Obstacle(58.0f, 1));
            obstacleList.Add(new Obstacle(80.0f, 100));
                break;
        }
    }

    void Start()
    {
        om = GameObject.Find("ObstacleManager");
        portalPrefab = Resources.Load("game2/object/Portal") as GameObject;
        enemyPrefab = Resources.Load("game2/object/Enemy") as GameObject;
        enemyPrefab2 = Resources.Load("game2/object/Enemy2") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * Game2Controller.speed;

        if(Game2Controller.stage == 0 && distance > 65f)
        {
            // Game2Controller.Setting(0);
            // SceneManager.LoadScene("MiniGame2", LoadSceneMode.Single);
        }

        if (obstacleList.Count > 0)
        {
            nextObstacle = obstacleList[0];
            if(nextObstacle.distance <= distance)
            {
                genEnemy(nextObstacle.type);
                obstacleList.Remove(nextObstacle);
                if (obstacleList.Count == 0) nextObstacle = null;
                else nextObstacle = obstacleList[0];
            }
        }
    }
}
