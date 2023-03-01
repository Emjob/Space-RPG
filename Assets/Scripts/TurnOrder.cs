using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnOrder : MonoBehaviour
{
    public GameObject Player;
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject enemyThree;

    //Dictionary<string, int> playerSpeed = new Dictionary<string, int>();
    public List<GameObject> speed;

    public bool startOfTurn;
    public bool changeTurn;

    public int i;
    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerOne");
        enemyOne = GameObject.FindGameObjectWithTag("EnemyOne");
        enemyTwo = GameObject.FindGameObjectWithTag("EnemyTwo");
        enemyThree = GameObject.FindGameObjectWithTag("EnemyThree");
        speed.Add(Player);
        speed.Add(enemyOne);
        speed.Add(enemyTwo);
        speed.Add(enemyThree);
    }
    private void Update()
    {
       
            if (startOfTurn == true)
            {
                speed.Sort(delegate (GameObject a, GameObject b)
                {
                    return (a.GetComponent<Stats>().Speed).CompareTo(b.GetComponent<Stats>().Speed);
                });
            
            speed.Reverse();
            startOfTurn = false;

        }

            if(changeTurn == true)
        {
            i = -1;
            i += 1;
            speed[i].GetComponent<Health>().turnStart = true;
            Debug.Log(i.ToString());
            changeTurn = false;
        }
        
    }
}
