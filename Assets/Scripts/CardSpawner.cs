using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{

    public GameObject[] spawnPoint;
    public GameObject damageCard;
    public GameObject healthCard;
    public GameObject[] Deck;

    enemyAttack turnStart;
    PlayerHealth maxHealth;

    public bool myTurn;
    public bool enemy1;
    public bool enemy2;
    public bool enemy3;
    public int counter;

    
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        
       

        //  Instantiate(damageCard,parents[1]);
    }

    // Update is called once per frame
    public void Update()
    {
        if(counter == 5)
                {
            enemy1 = true;
            enemy2 = true;
            enemy3 = true;
        }
        if (myTurn == false)
        {
            if (maxHealth.currentHealth >= maxHealth.maxHealth)
            {

                maxHealth.currentHealth = maxHealth.maxHealth;
            }
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(Deck[Random.Range(0, Deck.Length)], spawnPoint[i].transform.position, Quaternion.identity);
            }
            myTurn = true;
        }
    }
}
