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

    public bool myTurn;
    public bool enemy1;
    public bool enemy2;
    public bool enemy3;
    public int counter;

    
    // Start is called before the first frame update
    void Start()
    {
        turnStart = GameObject.Find("Enemy").GetComponent<enemyAttack>();
        
       

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
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(Deck[Random.Range(0, Deck.Length)], spawnPoint[i].transform.position, Quaternion.identity);
            }
            myTurn = true;
        }
    }
}
