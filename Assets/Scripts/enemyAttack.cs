using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{

   // public bool turnStart;

    public int damage;
    public int Heal;

    CardSpawner turnCounter;
    // Start is called before the first frame update
    void Start()
    {
        turnCounter = GameObject.Find("Holder").GetComponent<CardSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(turnCounter.enemy1 == true)
        {
        int n = Random.Range(0, 2);
            if(n == 0)
            {
                GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(damage);
                GetComponent<Renderer>().material.color = new Color(255, 0, 0);

            }
            if(n == 1)
            {
                GetComponent<EnemyHealth>().Heal(Heal);
                GetComponent<Renderer>().material.color = new Color(255, 0, 211);
            }
            turnCounter.enemy1 = false;
            turnCounter.myTurn = false;
            turnCounter.counter = 0;
        }
    }
}
