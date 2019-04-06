using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    public static float thrust = 10f;
    Player player;
    void Start()
    {
        player = (Player)GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // 
            bool attack = false;
            GameObject[] enemyobjects = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enemyob in enemyobjects)
            {
                float d = Vector3.Distance(enemyob.transform.position, player.gameObject.transform.position);
                if(d < 5)
                {
                    player.Punch();
                    attack = true;
                }
            }

            if(!attack)
            {
                player.Jump(thrust);
            }
        }
    }
}
