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

        if (startOfTurn == true)
        {
            hand.con = 0;
            hand.Draw();
            speed.Clear();
            speed.Add(GameObject.Find("TurnStarter"));
            for (int i = 0; i < enemies.Length; i++)
            {
                speed.Add(enemies[i]);
            }
            for (int i = 0; i < players.Length; i++)
            {
                speed.Add(players[i]);
            }
            i = 0;
            speed.Sort(delegate (GameObject a, GameObject b)
            {
                return (a.GetComponent<Stats>().Speed).CompareTo(b.GetComponent<Stats>().Speed);
            });

            speed.Reverse();

            startOfTurn = false;
        }

        
            if (i >= speed.Count)
            {
                startOfTurn = true;
                i = 0;
            }
            if(speed[i].CompareTag("TurnStarter"))
        {
            i = 0;
        }
            if (speed[i].CompareTag("Player") && startOfTurn == false)
            {
                speed[i].GetComponent<PlayerAttack>().myturn = true;
            }
            if (speed[i].CompareTag("Enemy") && startOfTurn == false)
            {
                speed[i].GetComponent<enemyAttack>().myturn = true;
            }

        

        if (Input.GetKeyDown("c"))
        {
            changeTurn = true;
        }
        if (Input.GetKeyDown("s"))
        {
            startOfTurn = true;
        }
        //    Debug.Log(speed[i] + "");


    }
}
