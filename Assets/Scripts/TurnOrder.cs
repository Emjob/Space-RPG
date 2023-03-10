using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnOrder : MonoBehaviour
{


    GameObject[] enemies = new GameObject[3];
    GameObject[] players = new GameObject[3];
    //Dictionary<string, int> playerSpeed = new Dictionary<string, int>();
    public List<GameObject> speed;

    public bool startOfTurn;
    public bool changeTurn;

    public int i;

    CardSpawner hand;

    private void Start()
    {
        hand = GameObject.Find("Holder").GetComponent<CardSpawner>();
    }
    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (startOfTurn == true || i > speed.Count)
            {
            hand.Draw();
            speed.Clear();
            for (int i = 0; i < enemies.Length; i++)
            {
                speed.Add(enemies[i]);
            }
            for (int i = 0; i < players.Length; i++)
            {
                speed.Add(players[i]);
            }
            i = -1;
                speed.Sort(delegate (GameObject a, GameObject b)
                {
                    return (a.GetComponent<Stats>().Speed).CompareTo(b.GetComponent<Stats>().Speed);
                });
            
            speed.Reverse();
        //    speed[1].GetComponent<Health>().EnemyTurn();
            startOfTurn = false;

        }

            if(changeTurn == true)
        {

            i += 1;
            if (i > speed.Count)
            {
                startOfTurn = true;
                changeTurn = false;
            }
            if (speed[i].CompareTag("Player"))
                {
                    speed[i].GetComponent<Health>().myturn = true;

                }
                if (speed[i].CompareTag("Enemy"))
                {
                    speed[i].GetComponent<Health>().myturn = true;
                    speed[i].GetComponent<enemyAttack>().EnemyTurn();
                }
                
            }
           
            if(Input.GetKeyDown("c"))
        {
            changeTurn = true;
        }
            if(Input.GetKeyDown("s"))
        {
            startOfTurn = true;
        }
        //    Debug.Log(speed[i] + "");
        
        
    }
}
