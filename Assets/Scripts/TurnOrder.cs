using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnOrder : MonoBehaviour
{


    public GameObject[] enemies = new GameObject[3];
    GameObject[] players = new GameObject[3];
    //Dictionary<string, int> playerSpeed = new Dictionary<string, int>();
    public List<GameObject> speed;

    public bool startOfTurn;
    public bool changeTurn;

    public int i;
    public void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        
        
        for (int i = 0; i < enemies.Length; i++)
        {
            speed.Add(enemies[i]);
        }
        for (int i = 0; i < players.Length; i++)
        {
            speed.Add(players[i]);
        }
    }
    private void Update()
    {
       
            if (startOfTurn == true || i > speed.Count)
            {
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
            
            if (speed[i].CompareTag("Player"))
            {
                speed[i].GetComponent<Health>().Playerturn();
                
            }
            if(speed[i].CompareTag("Enemy"))
            {
                speed[i].GetComponent<Health>().EnemyTurn();
            }
            Debug.Log(speed[i] + "");
            changeTurn = false;
            
        }
        
    }
}
